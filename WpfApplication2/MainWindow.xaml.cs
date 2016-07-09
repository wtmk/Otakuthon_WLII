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
using System.Data;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections;
using System.ComponentModel;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window, INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            
           // string read_csv = File.ReadAllText(@"C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Contest_Database_Test.csv");
            //Viewer_window Admin_window = new Viewer_window();
           // CSVdata = parseCSV("C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Contest_Database_Test.csv");
            InitializeComponent();
            MediaPlayer.Volume = 200;
            DataContext = this;
#if DEBUG
            myList = GetDataTabletFromCSVFile("C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Movies\\csv_list.csv");
#else
            myList = GetDataTabletFromCSVFile(@".\Movies\csv_list.csv");
#endif
            //myList = GetDataTabletFromCSVFile("C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Movies\\csv_list.csv");

            dataGrid.ItemsSource = myList.AsDataView();
            //dataGrid.IsReadOnly = true;
           // Child viewer_window = new Child();
            //viewer_window.Show();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Child childWindow = new Child();
            childWindow.MyEvent += new EventHandler(childWindow_MyEvent);

            childWindow.ShowDialog();
        }

        void childWindow_MyEvent(object sender, EventArgs e)
        {
            // handle event
            MessageBox.Show("Handle");
        }

        private void IsPlaying(bool flag)
        {
            btnPlay.IsEnabled = flag;
            btnStop.IsEnabled = flag;
            btnMoveBack.IsEnabled = flag;
            btnMoveForward.IsEnabled = flag;
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
            MediaPlayer.Position -= TimeSpan.FromSeconds(10);
        }

        private void btnMoveForward_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position += TimeSpan.FromSeconds(10);
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

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return csvData;
        }

        private void button_up_p1_Click(object sender, RoutedEventArgs e)
        {
            p1_score++;
            p1_score_label = p1_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p1_score_label)));
        }

        private void button_down_p1_Click(object sender, RoutedEventArgs e)
        {
            p1_score--;
            p1_score_label = p1_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p1_score_label)));
        }

        private void button_up_p2_Click(object sender, RoutedEventArgs e)
        {
            p2_score++;
            p2_score_label = p2_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p2_score_label)));
        }

        private void button_down_p2_Click(object sender, RoutedEventArgs e)
        {
            p2_score--;
            p2_score_label = p2_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p2_score_label)));
        }

        private void button_up_p3_Click(object sender, RoutedEventArgs e)
        {
            p3_score++;
            p3_score_label = p3_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p3_score_label)));
        }

        private void button_down_p3_Click(object sender, RoutedEventArgs e)
        {
            p3_score--;
            p3_score_label = p3_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p3_score_label)));
        }

        private void button_up_p4_Click(object sender, RoutedEventArgs e)
        {
            p4_score++;
            p4_score_label = p4_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p4_score_label)));
        }

        private void button_down_p4_Click(object sender, RoutedEventArgs e)
        {
            p4_score--;
            p4_score_label = p4_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p4_score_label)));
        }

        private void button_reset_Click(object sender, RoutedEventArgs e)
        {
            p1_score = 0;
            p2_score = 0;
            p3_score = 0;
            p4_score = 0;
            p1_score_label = p1_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p1_score_label)));
            p2_score_label = p2_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p2_score_label)));
            p3_score_label = p3_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p3_score_label)));
            p4_score_label = p4_score.ToString();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(p4_score_label)));
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
           
        dataGrid.ItemsSource = myList.AsDataView() ;

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedFile = (System.Data.DataRowView)dataGrid.SelectedItems[0];
                var selected_video = selectedFile.Row.ItemArray[3];
                selected_video_name = (string)selected_video;
                if (selected_video_name != null)
                {
#if DEBUG
                    string path = "C:\\Users\\AwesomePC\\Documents\\Visual Studio 2015\\Projects\\WpfApplication2\\WpfApplication2\\Movies\\" + selected_video_name;
                    MediaPlayer.Source = new Uri(path);
#else
                    string path = "Movies\\" + selected_video_name;
                    string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
                               MediaPlayer.Source = new Uri(appPath+path);
#endif
                }
                else
                {
                    MessageBox.Show("Nothing selected!");
                }
            }
            catch { }
        }

      
    }
}

