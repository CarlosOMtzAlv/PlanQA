using System;
using System.Windows;
using System.Data;
using WPF.Plant.Metrics.Helpers;

namespace WPF.Plant.Metrics.Windows
{
    /// <summary>
    /// Interaction logic for WinMenu.xaml
    /// </summary>
    public partial class WinMenu : Window
    {
        public WinMenu()
        {
            InitializeComponent();
        }
        
        private void Quality_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Quality.Visibility = Visibility.Visible;
                Efficiency.Visibility = Visibility.Hidden;
                MachineSpeed.Visibility = Visibility.Hidden;
                CoilChange.Visibility = Visibility.Hidden;
                TimeOut.Visibility = Visibility.Hidden;
                dpDetails.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Efficiency_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Quality.Visibility = Visibility.Hidden;
                Efficiency.Visibility = Visibility.Visible;
                MachineSpeed.Visibility = Visibility.Hidden;
                CoilChange.Visibility = Visibility.Hidden;
                TimeOut.Visibility = Visibility.Hidden;
                dpDetails.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CoilChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Quality.Visibility = Visibility.Hidden;
                Efficiency.Visibility = Visibility.Hidden;
                MachineSpeed.Visibility = Visibility.Hidden;
                CoilChange.Visibility = Visibility.Visible;
                TimeOut.Visibility = Visibility.Hidden;
                dpDetails.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MachineSpeed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Quality.Visibility = Visibility.Hidden;
                Efficiency.Visibility = Visibility.Hidden;
                MachineSpeed.Visibility = Visibility.Visible;
                CoilChange.Visibility = Visibility.Hidden;
                TimeOut.Visibility = Visibility.Hidden;
                dpDetails.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TimeOut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Quality.Visibility = Visibility.Hidden;
                Efficiency.Visibility = Visibility.Hidden;
                MachineSpeed.Visibility = Visibility.Hidden;
                CoilChange.Visibility = Visibility.Hidden;
                TimeOut.Visibility = Visibility.Visible;
                dpDetails.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow win = new MainWindow();
                win.Show();
                win.WindowState = WindowState.Maximized;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Quality.Visibility = Visibility.Hidden;
                Efficiency.Visibility = Visibility.Hidden;
                MachineSpeed.Visibility = Visibility.Hidden;
                CoilChange.Visibility = Visibility.Hidden;
                TimeOut.Visibility = Visibility.Hidden;
                dpDetails.Visibility = Visibility.Visible;
                FillDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void FillDataTable()
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = ManagerDB.GetInstance().DTExecute(Constants.DB_SEL_METRICS, DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));
                dtDetails.ItemsSource = dtData.DefaultView;
                dtDetails.DataContext = dtData;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((dpStartdate.Text != "") && (dpEnddate.Text != ""))
                {
                    string start = DateTime.Parse(dpStartdate.Text).ToString("yyyy/MM/dd");
                    string end = DateTime.Parse(dpEnddate.Text).ToString("yyyy/MM/dd");
                    DataTable dtData = new DataTable();
                    dtData = ManagerDB.GetInstance().DTExecute(Constants.DB_SEL_METRICS, start, end);
                    dtDetails.ItemsSource = dtData.DefaultView;
                    dtDetails.DataContext = dtData;
                }
                else
                {
                    MessageBox.Show("Los campos Fecha Inicio y Fecha Fin deben llevar valor.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
