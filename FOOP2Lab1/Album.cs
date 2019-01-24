using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP2Lab1
{
    class Album
    {
        public string AlbumName { get; set; }
        //public int ReleaseDate { get; set; }
        public DateTime Released { get; set; }
        public int Sales { get; set; }

        public Album(string albumName, DateTime released, int sales)
        {
            AlbumName = albumName;
            Released = released;
            Sales = sales;
        }

        public override string ToString()
        {
            int yearsAvailable = 2019 - (int)Released.Year;
            return string.Format("{0}\t{1}\t{2}\t{3}", AlbumName, Released.ToString("yyyy"), Sales, yearsAvailable);
        }
    }
}
