using System;
using System.Collections.Generic;

namespace NateSucksAtPunchout.DataModel
{
    public partial class BigGame
    {
        public BigGame()
        {
            Finishes = new HashSet<Finish>();
            Kills = new HashSet<Kill>();
        }

        public long Year { get; set; }
        public byte[] Date { get; set; }
        public double BuyIn { get; set; }
        public long LocationId { get; set; }
        public double Length { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Finish> Finishes { get; set; }
        public virtual ICollection<Kill> Kills { get; set; }
    }
}
