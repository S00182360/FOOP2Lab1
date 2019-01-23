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
        public List<Album> Albums { get; set; }
        static Random r1 = new Random();

        public List<Album> SetAlbums()
        {
            List<Album> albums = new List<Album>();
            int noAlbums = r1.Next(1, 10);
            string albumName;
            int releaseYear;
            int sales;
            for (int i = 0; i <= noAlbums; i++)
            {
                albumName = "Album " + (i + 1);
                releaseYear = r1.Next(Year, 2019);
                sales = r1.Next(1000, 10000);
                albums.Add(new Album(albumName, releaseYear, sales));
            }
            return albums;
        }
        public string SetDetail()
        {
            string detail = "";

            detail += "Name:  " + BandName;
            detail += "\nYear Formed:  " + Year;
            detail += "\nMembers: ";
            for (int i = 0; i < Members.Count; i++)
            {
                if (i < Members.Count - 1)
                    detail += Members[i] + ", ";
                else
                    detail += Members[i] + ".";
            }

            return detail;
        }

        public Band()
        {

        }
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
