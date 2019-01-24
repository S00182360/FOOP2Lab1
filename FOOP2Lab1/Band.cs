using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP2Lab1
{
    abstract class Band : IComparable
    {
        public enum Genres { Rock, Pop, Indie};
        public Genres Genre { get; set; }
        public string BandName { get; set; }
        //public int Year { get; set; }
        public DateTime YearFormed { get; set; }
        public List<string> Members { get; set; }
        public List<Album> Albums { get; set; }
        static Random r1 = new Random();

        public List<Album> SetAlbums()
        {
            List<Album> albums = new List<Album>();
            int noAlbums = r1.Next(1, 10);
            string albumName;
            //int releaseYear;
            int sales;
            for (int i = 0; i <= noAlbums; i++)
            {
                albumName = "Album " + (i + 1);
                //releaseYear = r1.Next(Year, 2019);
                sales = r1.Next(1000, 10000);
                albums.Add(new Album(albumName, SetReleaseDate(), sales));
            }
            return albums;
        }
        public string SetDetail()
        {
            string detail = "";

            detail += "Name:  " + BandName;
            detail += "\nYear Formed:  " + YearFormed.ToString("yyyy");
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


        private DateTime SetReleaseDate()
        {
            DateTime released = YearFormed;
            TimeSpan yearsActive = DateTime.Today - YearFormed;
            int maxMinutes = (int)yearsActive.TotalMinutes;
            int addMinutes = r1.Next(0, maxMinutes);

            TimeSpan newSpan = new TimeSpan(0, addMinutes, 0);
            released += newSpan;
            return released;
        }
    }
}
