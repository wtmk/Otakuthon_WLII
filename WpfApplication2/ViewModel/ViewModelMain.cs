using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Otakuthon_App.Model;
using Otakuthon_App.Helpers;
using System.Data;
using Otakuthon_App.Data;
using System.Windows;
using System.Windows.Data;

namespace Otakuthon_App.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        
        public ObservableCollection<Video> Videos { get; set; }
        public DataTable myList = new DataTable();
   
        object _SelectedVideo;
        public object SelectedVideo
        {
            get
            {
                return _SelectedVideo;
            }
            set
            {
                if (_SelectedVideo != value)
                {
                    _SelectedVideo = value;
                    RaisePropertyChanged("SelectedVideo");
                }
            }
        }
        
        public ViewModelMain()
        {

           
            #if DEBUG
            myList = DatabaseCSV.GetDataTabletFromCSVFile("C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Movies\\csv_list2.csv");
            #else
                        myList = DatabaseCSV.GetDataTabletFromCSVFile(@".\Movies\csv_list2.csv");
            #endif 
           // myList = DatabaseCSV.GetDataTabletFromCSVFile("C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Movies\\csv_list2.csv");

            Videos = new ObservableCollection<Video>();
                                  
            foreach (DataRow row in myList.Rows)
                     { Video temp = new Video { AnimeName = (string)row[0], Character = (string)row[1], Voice_Actor = (string)row[2], AnimeGenre = (string)row[3], Filename = (string)row[4], Anime_image = (string)row[5], Is_used = (string)row[6], Is_played=Convert.ToBoolean(row[7]) };
                Videos.Add(temp);
                 
            }
        }

      }
}
