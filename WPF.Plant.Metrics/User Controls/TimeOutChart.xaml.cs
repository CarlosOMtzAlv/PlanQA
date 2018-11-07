using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Geared;
using WPF.Plant.Metrics.Models;

namespace WPF.Plant.Metrics.User_Controls
{
    /// <summary>
    /// Interaction logic for TimeOutChart.xaml
    /// </summary>
    public partial class TimeOutChart : UserControl, INotifyPropertyChanged
    {
        private double _axisMax;
        private double _axisMin;
        private double _trend;
        private double _currentLecture;
        private string _turno1;
        private string _turno2;
        private string _turno3;

        public TimeOutChart()
        {
            InitializeComponent();

            var mapper = Mappers.Xy<TimeOutModel>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<TimeOutModel>(mapper);

            //the values property will store our values array
            ChartValues = new GearedValues<TimeOutModel>();
            ChartValues.WithQuality(Quality.Highest);

            //lets set how to display the X Labels
            DateTimeFormatter = value => new DateTime((long)value).ToString("mm:ss");

            //AxisStep forces the distance between each separator in the X axis
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);

            //The next code simulates data changes every 300 ms

            IsReading = false;

            DataContext = this;
        }

        public GearedValues<TimeOutModel> ChartValues { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        public bool IsReading { get; set; }

        private void Read()
        {
            var r = new Random();

            while (IsReading)
            {
                Thread.Sleep(150);
                var now = DateTime.Now;

                _trend += r.Next(-8, 10);

                ChartValues.Add(new TimeOutModel
                {
                    DateTime = now,
                    Value = _trend
                });

                SetAxisLimits(now);

                //lets only use the last 150 values
                if (ChartValues.Count > 150) ChartValues.RemoveAt(0);

                CurrentLecture = _trend;


                // CMABIAR CONFORME AL INDICADOR DE CADA TURNO, SE PONE AQUI COMO MUESTRA
                Turno1 = DateTime.Now.ToString("dd MMMM yyyy");
                Turno2 = DateTime.Now.ToString("dd MMMM yyyy");
                Turno3 = DateTime.Now.ToString("dd MMMM yyyy");
            }
        }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(20).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(10).Ticks; // and 8 seconds behind
        }

        private void InjectStopOnClick(object sender, RoutedEventArgs e)
        {
            IsReading = !IsReading;
            if (IsReading) Task.Factory.StartNew(Read);
        }

        public double CurrentLecture
        {
            get { return _currentLecture; }
            set
            {
                _currentLecture = value;
                OnPropertyChanged("CurrentLecture");
            }
        }

        public string Turno1
        {
            get { return _turno1; }
            set
            {
                _turno1 = value;
                OnPropertyChanged("Turno1");
            }
        }
        public string Turno2
        {
            get { return _turno2; }
            set
            {
                _turno2 = value;
                OnPropertyChanged("Turno2");
            }
        }

        public string Turno3
        {
            get { return _turno3; }
            set
            {
                _turno3 = value;
                OnPropertyChanged("Turno3");
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
    }
}
