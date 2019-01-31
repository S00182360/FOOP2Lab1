using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;

namespace FOOP2Lab1
{
    public partial class MainWindow : Window
    {
        List<Band> BandList = new List<Band>();
        List<Band> FilterList = new List<Band>();
        List<string> cbxOptions = new List<string> { "All", "Rock", "Pop", "Indie" };

        public MainWindow()
        {
            InitializeComponent();

            #region INITAL BAND DECLARATION
            //Set bands for inital coding
            RockBand b1 = new RockBand
            {
                BandName = "Muse",
                //Year = 1994,
                YearFormed = new DateTime(1994, 01, 01),
                Members = new List<string> { "Matthew Belamy", "Chris Wolstenholme", "Dominic Howard" },
                Genre = Band.Genres.Rock
            };
            RockBand b2 = new RockBand
            {
                BandName = "Panic at the Disco",
                //Year = 2004,
                YearFormed = new DateTime(2004, 01, 01),
                Members = new List<string> { "Brendon Urie", "Ryan Ross", "Dallon Weekes",
                    "Jon Walker", "Spencer Smith", "Brent Wilson" },
                Genre = Band.Genres.Rock
            };
            PopBand b3 = new PopBand
            {
                BandName = "The Beach Boys",
                //Year = 1961,
                YearFormed = new DateTime(1961, 01, 01),
                Members = new List<string> { "Brian Wilson", "Mike Love", "Dennis Wilson", "Carl Wilson"},
                Genre = Band.Genres.Pop
            };
            PopBand b4 = new PopBand
            {
                BandName = "One Direction",
                //Year = 2010,
                YearFormed = new DateTime(2010, 01, 01),
                Members = new List<string> { "Niall Horan", "Liam Payne", "Harry Styles",
                    "Louis Tomlinson", "Zayne Malik" },
                Genre = Band.Genres.Pop
            };
            IndieBand b5 = new IndieBand
            {
                BandName = "Artic Monkeys",
                //Year = 2002,
                YearFormed = new DateTime(2002, 01, 01),
                Members = new List<string> {  "Alex Turner", "Matt Helders", "Jamie Cook",
                    "Nick O'Malley", "Andy Nicholson", "Glyn Jones" },
                Genre = Band.Genres.Indie
            };
            IndieBand b6 = new IndieBand
            {
                BandName = "The The",
                //Year = 1979,
                YearFormed = new DateTime(1979, 01, 01),
                Members = new List<string> { "Matt Johnson", "Johnny Marr", "Jools Holland" },
                Genre = Band.Genres.Indie
            };
            #endregion INITAL BAND DECLARATION

            #region ALBUM SET
            b1.Albums = b1.SetAlbums();
            b2.Albums = b2.SetAlbums();
            b3.Albums = b3.SetAlbums();
            b4.Albums = b4.SetAlbums();
            b5.Albums = b5.SetAlbums();
            b6.Albums = b6.SetAlbums();
            #endregion ALBUM SET

            #region ADD BANDS TO LIST
            //Add to bandlist
            BandList.Add(b1);
            BandList.Add(b2);
            BandList.Add(b3);
            BandList.Add(b4);
            BandList.Add(b5);
            BandList.Add(b6);
            BandList.Sort();
            #endregion ADD BANDS TO LIST

            //BandList.Reverse();
            lbxBandList.ItemsSource = BandList;

            cbxFilterGenre.ItemsSource = cbxOptions;
            cbxFilterGenre.SelectedIndex = 0;
        }

        private void LbxBandList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selected = (Band)lbxBandList.SelectedValue;
            if(selected != null)
            {
                tbkBandDetail.Text = "";
                tbkBandDetail.Text = selected.SetDetail();
                lbxAlbums.ItemsSource = selected.Albums;
            }
        }



        private void Filter(string selected)
        {
            FilterList.Clear();
            foreach (var band in BandList)
            {
                if(band.Genre.ToString() == selected)
                {
                    FilterList.Add(band);
                }
            }
        }

        private void CbxFilterGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string genreSelect = (string)cbxFilterGenre.SelectedValue;
            int selected = cbxFilterGenre.SelectedIndex;
            switch(selected)
            {
                case 0:
                    lbxBandList.ItemsSource = null;
                    lbxBandList.ItemsSource = BandList;
                    break;
                case 1:
                case 2:
                case 3:
                    Filter(genreSelect);
                    lbxBandList.ItemsSource = null;
                    lbxBandList.ItemsSource = FilterList;
                    break;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(lbxBandList.SelectedItem != null)
            {
                string json = JsonConvert.SerializeObject(lbxBandList.SelectedItem, Formatting.Indented);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = ".json";
                Nullable<bool> result = sfd.ShowDialog();

                if (result == true)
                {
                    string fileName = sfd.FileName;
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.Write(json);
                    }
                }
            }
        }
    }
}
