using System;
using System.Collections.Generic;

namespace NateSucksAtPunchout.DataModel
{
    public partial class Kill
    {
        public long BigGame { get; set; }
        public string Killed { get; set; }
        public string Killer { get; set; }

        public virtual BigGame BigGameNavigation { get; set; }
        public virtual Player KilledNavigation { get; set; }
        public virtual Player KillerNavigation { get; set; }
    }
}
