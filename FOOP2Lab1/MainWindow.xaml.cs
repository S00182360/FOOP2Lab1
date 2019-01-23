using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FOOP2Lab1
{
    public partial class MainWindow : Window
    {
        List<Band> BandList = new List<Band>();

        public MainWindow()
        {
            InitializeComponent();
            #region INITAL BAND DECLARATION
            //Set bands for inital coding
            RockBand b1 = new RockBand
            {
                BandName = "Muse",
                Year = 1994,
                Members = new List<string> { "Matthew Belamy", "Chris Wolstenholme", "Dominic Howard" }
            };
            RockBand b2 = new RockBand
            {
                BandName = "Panic at the Disco",
                Year = 2004,
                Members = new List<string> { "Brendon Urie", "Ryan Ross", "Dallon Weekes",
                    "Jon Walker", "Spencer Smith", "Brent Wilson" }
            };
            PopBand b3 = new PopBand
            {
                BandName = "The Beach Boys",
                Year = 1961,
                Members = new List<string> { "Brian Wilson", "Mike Love", "Dennis Wilson", "Carl Wilson"}
            };
            PopBand b4 = new PopBand
            {
                BandName = "One Direction",
                Year = 2010,
                Members = new List<string> { "Niall Horan", "Liam Payne", "Harry Styles",
                    "Louis Tomlinson", "Zayne Malik" }
            };
            IndieBand b5 = new IndieBand
            {
                BandName = "Artic Monkeys",
                Year = 2002,
                Members = new List<string> {  "Alex Turner", "Matt Helders", "Jamie Cook",
                    "Nick O'Malley", "Andy Nicholson", "Glyn Jones" }
            };
            IndieBand b6 = new IndieBand
            {
                BandName = "The The",
                Year = 1979,
                Members = new List<string> { "Matt Johnson", "Johnny Marr", "Jools Holland" }
            };
            #endregion INITAL BAND DECLARATION

            //Add to bandlist
            BandList.Add(b1);
            BandList.Add(b2);
            BandList.Add(b3);
            BandList.Add(b4);
            BandList.Add(b5);
            BandList.Add(b6);
            BandList.Sort();
            //BandList.Reverse();
            lbxBandList.ItemsSource = BandList;
        }
    }
}
