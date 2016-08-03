using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.IO;
using System.ComponentModel;
using Otakuthon_App.Model;
using System.Collections.ObjectModel;
using Otakuthon_App.Data;


namespace Otakuthon_App.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
       
        public List<string[]> CSVdata { get; set; }
        public DataSet ds = new DataSet("Temp");
        public DataTable myList = new DataTable();
        public string selected_video_name;
        public string p1_score_label { get; set; }
        public string p2_score_label { get; set; }
        public string p3_score_label { get; set; }
        public string p4_score_label { get; set; }
        public int p1_score, p2_score, p3_score, p4_score = 0;

        //public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {

            InitializeComponent();
            MediaPlayer.Volume = 400;

        }

          private void IsPlaying(bool flag)
        {
            btnPlay.IsEnabled = flag;
            btnStop.IsEnabled = flag;
            btnMoveBack.IsEnabled = flag;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            IsPlaying(true);
            if (btnPlay.Content.ToString() == "Play")
            {
                MediaPlayer.Play();
                btnPlay.Content = "Pause";
            }
            else
            {
                MediaPlayer.Pause();
                btnPlay.Content = "Play";
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
            btnPlay.Content = "Play";
            IsPlaying(false);
            btnPlay.IsEnabled = true;
        }

        private void btnMoveBack_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
            MediaPlayer.Position = TimeSpan.Zero;
            MediaPlayer.Play();
        }

                private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box 
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Videos"; // Default file name 
            dialog.DefaultExt = ".avi"; // Default file extension 
            // dialog.Filter = "*.avi|*.mp4"; // Filter files by extension  
            string[] dirs = Directory.GetFiles(@"c:\", "c*");
            // Show open file dialog box 
            Nullable<bool> result = dialog.ShowDialog();
            

            // Process open file dialog box results  
            if (result == true)
            {
                // Open document  
                MediaPlayer.Source = new Uri(dialog.FileName);
                btnPlay.IsEnabled = true;
            }
        }  


        private void button_reset_Click(object sender, RoutedEventArgs e)
        {
           // p1_score = 0;
           // p2_score = 0;
           // p3_score = 0;
           // p4_score = 0;
           // p1_score_label = p1_score.ToString();
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p1_score_label)));
           // p2_score_label = p2_score.ToString();
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p2_score_label)));
           // p3_score_label = p3_score.ToString();
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p3_score_label)));
           // p4_score_label = p4_score.ToString();
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p4_score_label)));
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
        
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            
            try
            {
                Video selectedFile = (Video)dataGrid.SelectedItems[0];

               
             
                if (selectedFile.Filename != null)
                {
#if DEBUG
                    string path = "C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Movies\\" + selectedFile.Filename;
                    MediaPlayer.Source = new Uri(path);
#else
                    string path = "Movies\\" + selectedFile.Filename;
                    string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
                               MediaPlayer.Source = new Uri(appPath+path);
#endif
                }
                else
                {
                    MessageBox.Show("Nothing selected!");
                }
            }
            catch (Exception t)
            { Console.WriteLine("{0} Exception caught.", t);
            }
        }

       }
}

