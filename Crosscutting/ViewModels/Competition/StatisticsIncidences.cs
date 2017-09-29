using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Crosscutting.ViewModels.Competition
{
    public class StatisticsIncidences
    {
        public List<Booking> Bookings { get; set; }
        public List<Goal> Goals { get; set; }

        public int OffsideLocal { get; set; }

        public int OffsideVisitor { get; set; }

        public int PosessionLocal { get; set; }

        public int PosessionVisitor { get; set; }

        public int CornersLocal { get; set; }

        public int CornersVisitor { get; set; }
    }
}
