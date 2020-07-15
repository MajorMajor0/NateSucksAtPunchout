using System;
using System.Collections.Generic;

namespace NateSucksAtPunchout.DataModel
{
    public partial class Finish
    {
        public long Year { get; set; }
        public string Player { get; set; }
        public double Amount { get; set; }
        public double Time { get; set; }
        public long Place { get; set; }
        public long? RecordedKills { get; set; }

        public virtual Player PlayerNavigation { get; set; }
        public virtual BigGame YearNavigation { get; set; }
    }
}
