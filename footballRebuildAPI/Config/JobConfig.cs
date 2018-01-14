using System;

namespace Football.API.Config
{

    public class JobConfig
    {
        /// <summary>
        /// Name of the service to run
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time in seconds between runs
        /// </summary>
        public IntervalSettings Settings { get; set; }

        public bool Enabled { get; set; }

    }

    public class IntervalSettings
    {
        public TimeSpan Interval { get; set; }

        public string Day { get; set; }

        public string Time { get; set; }

        public DayOfWeek DayEnum
        {
            get
            {
                return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Day);
            }
        }
    }
}
