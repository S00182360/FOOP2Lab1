using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP2Lab1
{
    abstract class Band : IComparable
    {
        public string BandName { get; set; }
        public int Year { get; set; }
        public List<string> Members { get; set; }

        public int CompareTo(object obj)
        {
            Band that = (Band)obj;
            return BandName.CompareTo(that.BandName);
        }

        public override string ToString()
        {
            return BandName;
        }
    }
}
