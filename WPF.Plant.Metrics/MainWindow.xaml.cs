using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using WPF.Plant.Metrics.Windows;
using System.ComponentModel;

namespace WPF.Plant.Metrics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _fecha = DateTime.Now.ToString("dd MMMM yyyy");
        public MainWindow()
        {
            WindowState = WindowState.Maximized;
            InitializeComponent();
            Fecha = _fecha;
            DataContext = this;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WinMenu win = new WinMenu();
                win.Show();
                win.WindowState = WindowState.Maximized;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string Fecha
        {
            get { return _fecha; }
            set
            {
                _fecha = value;
                OnPropertyChanged("Fecha");
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
