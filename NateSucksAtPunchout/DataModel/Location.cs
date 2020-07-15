using System;
using System.Collections.Generic;

namespace NateSucksAtPunchout.DataModel
{
    public partial class Location
    {
        public Location()
        {
            BigGames = new HashSet<BigGame>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long? ZipCode { get; set; }

        public virtual ICollection<BigGame> BigGames { get; set; }
    }
}
