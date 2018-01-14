using Football.API.Config;
using Football.API.TaskRunner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Football.API.TaskRunner.Jobs
{
    public abstract class BaseJob : IBaseJob
    {
        private CancellationTokenSource _cancelationTokenSource = new CancellationTokenSource();

        public string Name { get; set; }
        public IntervalSettings Settings { get; set; }

        //protected ILoggerService _logger;

        public bool IsRunning { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();
        public Task Task { get; set; }
        public string ServiceName { get; set; }

        private object dateLock = new object();
        private DateTime nextRun;
        /// <summary>
        /// Thread safe time for next run, allows us to force a run of a badger at will
        /// </summary>
        public DateTime NextRun
        {
            get
            {
                lock (dateLock)
                {
                    return nextRun;
                }
            }
            set
            {
                lock (dateLock)
                {
                    nextRun = value;
                }
            }
        }



        public abstract Task<bool> Run();

        public void Start()
        {

            Task = Task.Run(async () =>
            {
                // Setup the first time to trigger
                NextRun = CalculateStart();

                while (!_cancelationTokenSource.IsCancellationRequested)
                {
                    //Check to see if the thread has been canceled to avoid locking the thread on wait
                    var waiting = true;

                    while (waiting)
                    {
                        Thread.Sleep(1000);

                        if (_cancelationTokenSource.IsCancellationRequested)
                        {
                            break;
                        }

                        //If a cancel was requested, end waiting and it will drop out of the loop
                        if (DateTime.Now >= NextRun)
                        {
                            waiting = false;
                        }
                    }

                    try
                    {
                        await Run();
                    }
                    catch (Exception e)
                    {
                        //Oh dear, the service errored
                        //_logger.LogError(e, "Error not handled correctly, error made it up to badger Start() : " + e.Message);
                    }


                    NextRun = DateTime.Now.Add(Settings.Interval);
                }
            });
        }

        public void Stop()
        {
            _cancelationTokenSource.Cancel();
        }

        private DateTime CalculateStart()
        {
            DateTime nextRun = DateTime.Now.Add(Settings.Interval);

            if (!string.IsNullOrEmpty(Settings.Time))
            {
                nextRun = DateTime.Parse(Settings.Time);

                if (!string.IsNullOrEmpty(Settings.Day))
                {
                    nextRun = GetNextWeekday(nextRun, Settings.DayEnum);

                    // If its already in the past today, make it grab the day next week rather than today
                    if (nextRun < DateTime.Now) nextRun = GetNextWeekday(nextRun.AddDays(1), Settings.DayEnum);
                }
                else
                {
                    // If the time is in the past, add a day to make it run tomorrow
                    if (nextRun < DateTime.Now) nextRun = nextRun.AddDays(1);
                }

            }

            return nextRun;
        }

        private DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        public void Setup(JobConfig config)
        {
            this.Settings = config.Settings;
            this.Name = config.Name;
            //_logger = ServiceConfiguration.ConsoleProvider.GetService<ILoggerService>();
        }

    }
}
