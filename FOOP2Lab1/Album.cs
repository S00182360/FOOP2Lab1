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
        public int ReleaseDate { get; set; }
        public int Sales { get; set; }

        public Album(string albumName, int releaseDate, int sales)
        {
            AlbumName = albumName;
            ReleaseDate = releaseDate;
            Sales = sales;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", AlbumName, ReleaseDate, Sales);
        }
    }
}
