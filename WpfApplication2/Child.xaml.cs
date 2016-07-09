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
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Child : Window
    {
        public event EventHandler MyEvent;

        protected void OnMyEvent()
        {
            if (this.MyEvent != null)
                this.MyEvent(this, EventArgs.Empty);
        }

        public Child()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Child_Loaded);
        }

        void Child_Loaded(object sender, RoutedEventArgs e)
        {
            // call event
            this.OnMyEvent();
        }
    }
}
