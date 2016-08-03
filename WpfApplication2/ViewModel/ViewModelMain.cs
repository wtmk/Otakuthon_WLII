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
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using System.Windows.Controls;

namespace Otakuthon_App.ViewModel
{
    class ViewModelMain : INotifyPropertyChanged
    {
        public ObservableCollection<Video> Videos { get; set; }
        public DataTable myList = new DataTable();
        int p1, p2, p3, p4 ,r = 0; 
   
       // object _SelectedVideo;
       // public object SelectedVideo
       // {
       //     get
       //     {
       //         return _SelectedVideo;
       //     }
       //     set
       //     {
       //         if (_SelectedVideo != value)
       //         {
       //             _SelectedVideo = value;
       //             RaisePropertyChanged("SelectedVideo");
       //         }
       //     }
       // }

        Game _game;

        public event PropertyChangedEventHandler PropertyChanged;

        public Game game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }

        public string scoreP1
        {
            get { return game.ScoreP1; }
            set
            {
                if (game.ScoreP1 != value)
                {
                    game.ScoreP1 = value;
                    RaisePropertyChanged("Scorep1");
                }
            }
        }
        public string scoreP2
        {
            get { return game.ScoreP2; }
            set
            {
                if (game.ScoreP2 != value)
                {
                    game.ScoreP2 = value;
                    RaisePropertyChanged("Scorep2");
                }
            }
        }
        public string scoreP3
        {
            get { return game.ScoreP3; }
            set
            {
                if (game.ScoreP3 != value)
                {
                    game.ScoreP3 = value;
                    RaisePropertyChanged("Scorep3");
                }
            }
        }
        public string scoreP4
        {
            get { return game.ScoreP4; }
            set
            {
                if (game.ScoreP4 != value)
                {
                    game.ScoreP4 = value;
                    RaisePropertyChanged("Scorep4");
                }
            }
        }
        public string roundPlayCount
        {
            get { return game.roundPlayCount; }
            set
            {
                if (game.roundPlayCount != value)
                {
                    game.roundPlayCount = value;
                    RaisePropertyChanged("roundPlayCount");
                }
            }
        }
        private MediaElement _mediaElementObject;

        public MediaElement MediaElementObject
        {
            get { return _mediaElementObject; }
            set { _mediaElementObject = value; RaisePropertyChanged(""); }
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
            
            _game = new Game { ScoreP1 = "0", ScoreP2 = "0", ScoreP3 = "0", ScoreP4 = "0", roundPlayCount = "0/7" };

            


        }

        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public string SourceUri
        {
            get
            {
                return ("C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Movies\\Background_otakuthon.png");
            }
        }

        #region Commands
        void Updatep1upExecute()
        {
            p1++;
            scoreP1 = p1.ToString();
            
        }
        void Updatep2upExecute()
        {

            p2++;
            scoreP2 = p2.ToString();
        }
        void Updatep3upExecute()
        {
            p3++;
            scoreP3 = p3.ToString();

        }
        void Updatep4upExecute()
        {
            p4++;
            scoreP4 = p4.ToString();

        }

        void round_counter()
        {

            r++;
            roundPlayCount = r.ToString() + "/7";
        }
        void round_counter_down()
        {
            if (r > 0)
                r--;
            roundPlayCount = r.ToString() + "/7";
        }

        void Updatep1downExecute()
        {
            if(p1>0)
            p1--;
            scoreP1 = p1.ToString();

        }
        void Updatep2downExecute()
        {
            if (p2 > 0)
                p2--;
            scoreP2 = p2.ToString();
        }
        void Updatep3downExecute()
        {
            if (p3 > 0)
                p3--;
            scoreP3 = p3.ToString();

        }
        void Updatep4downExecute()
        {
            if (p4 > 0)
                p4--;
            scoreP4 = p4.ToString();

        }

        void Update_reset_all()
        {
            p1 = 0;
            p2 = 0;
            p3 = 0;
            p4 = 0;
            r = 0;
            scoreP1 = p1.ToString();
            scoreP2 = p2.ToString();
            scoreP3 = p3.ToString();
            scoreP4 = p4.ToString();
            roundPlayCount = r.ToString()+"/7";

        }
        bool CanUpdateGameExecute()
        {
            return true;
        }

        public ICommand UpdateP1_up_score { get { return new RelayCommand(Updatep1upExecute, CanUpdateGameExecute); } }
        public ICommand UpdateP2_up_score { get { return new RelayCommand(Updatep2upExecute, CanUpdateGameExecute); } }
        public ICommand UpdateP3_up_score { get { return new RelayCommand(Updatep3upExecute, CanUpdateGameExecute); } }
        public ICommand UpdateP4_up_score { get { return new RelayCommand(Updatep4upExecute, CanUpdateGameExecute); } }
        public ICommand UpdateP1_down_score { get { return new RelayCommand(Updatep1downExecute, CanUpdateGameExecute); } }
        public ICommand UpdateP2_down_score { get { return new RelayCommand(Updatep2downExecute, CanUpdateGameExecute); } }
        public ICommand UpdateP3_down_score { get { return new RelayCommand(Updatep3downExecute, CanUpdateGameExecute); } }
        public ICommand UpdateP4_down_score { get { return new RelayCommand(Updatep4downExecute, CanUpdateGameExecute); } }
        public ICommand reset_all_the_things { get { return new RelayCommand(Update_reset_all, CanUpdateGameExecute); } }
        public ICommand video_up_count { get { return new RelayCommand(round_counter, CanUpdateGameExecute); } }
        public ICommand video_down_count { get { return new RelayCommand(round_counter_down, CanUpdateGameExecute); } }
        #endregion
    }
}
