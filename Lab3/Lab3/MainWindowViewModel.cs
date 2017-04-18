using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Lab3
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<String> Models { get; private set; }
        private String _sm;
        public String SelectedModel
        {
            get { return _sm; }
            set
            {
                _sm = value;
                ListsItems();
                SelectModel(Models, _sm);
                DoPropertyChanged(nameof(SelectedModel));
            }
        }

        private ObservableCollection<string> _EngineVolumes;
        public ObservableCollection<string> EngineVolumes
        {
            get { return _EngineVolumes; }
            set
            {
                _EngineVolumes = value;
                DoPropertyChanged(nameof(EngineVolumes));
            }
        }
        public String SelectedEngineVolume { get; set; }

        private ObservableCollection<string> _Gears { get; set; }
        public ObservableCollection<string> Gears
        {
            get { return _Gears; }
            set
            {
                _Gears = value;
                DoPropertyChanged(nameof(Gears));
            }
        }
        public String SelectedGear { get; set; }

        private ObservableCollection<string> _WheelDrives;
        public ObservableCollection<string> WheelDrives
        {
            get { return _WheelDrives; }
            set
            {
                _WheelDrives = value;
                DoPropertyChanged(nameof(WheelDrives));
            }
        }
        public String SelectedWheelDrive { get; set; }

        public Boolean Pink { get; set; }
        public Boolean Blue { get; set; }
        public Boolean Green { get; set; }
        public Boolean Black { get; set; }
        public Boolean Yellow { get; set; }

        private String _VisibilityPink;
        public String VisibilityPink
        {
            get { return _VisibilityPink; }
            set
            {
                _VisibilityPink = value;
                DoPropertyChanged(nameof(VisibilityPink));
            }
        }
        private String _VisibilityBlue;
        public String VisibilityBlue
        {
            get { return _VisibilityBlue; }
            set
            {
                _VisibilityBlue = value;
                DoPropertyChanged(nameof(VisibilityBlue));
            }
        }
        private String _VisibilityGreen;
        public String VisibilityGreen
        {
            get { return _VisibilityGreen; }
            set
            {
                _VisibilityGreen = value;
                DoPropertyChanged(nameof(VisibilityGreen));
            }
        }
        private String _VisibilityBlack;
        public String VisibilityBlack
        {
            get { return _VisibilityBlack; }
            set
            {
                _VisibilityBlack = value;
                DoPropertyChanged(nameof(VisibilityBlack));
            }
        }
        private String _VisibilityYellow;
        public String VisibilityYellow
        {
            get { return _VisibilityYellow; }
            set
            {
                _VisibilityYellow = value;
                DoPropertyChanged(nameof(VisibilityYellow));
            }
        }

        public bool HasClimateControl { get; set; }
        public bool HasHeatedWheel { get; set; }
        public bool HasRainSensor { get; set; }
        public bool HasParkingSensor { get; set; }

        private bool _EnabledClimateControl;
        public bool EnabledClimateControl
        {
            get { return _EnabledClimateControl; }
            set
            {
                _EnabledClimateControl = value;
                DoPropertyChanged(nameof(EnabledClimateControl));
            }
        }
        private bool _EnabledHeatedWheel;
        public bool EnabledHeatedWheel
        {
            get { return _EnabledHeatedWheel; }
            set
            {
                _EnabledHeatedWheel = value;
                DoPropertyChanged(nameof(EnabledHeatedWheel));
            }
        }
        private bool _EnabledRainSensor;
        public bool EnabledRainSensor
        {
            get { return _EnabledRainSensor; }
            set
            {
                _EnabledRainSensor = value;
                DoPropertyChanged(nameof(EnabledRainSensor));
            }
        }
        private bool _EnabledParkingSensor;
        public bool EnabledParkingSensor
        {
            get { return _EnabledParkingSensor; }
            set
            {
                _EnabledParkingSensor = value;
                DoPropertyChanged(nameof(EnabledParkingSensor));
            }
        }

        private ObservableCollection<string> _ParkingSensorTypes;
        public ObservableCollection<string> ParkingSensorTypes
        {
            get { return _ParkingSensorTypes; }
            set
            {
                _ParkingSensorTypes = value;
                DoPropertyChanged(nameof(ParkingSensorTypes));
            }
        }
        public String SelectedParkingSensorType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }

        public int Price { get; private set; }

        public void SelectModel(ObservableCollection<String> Models, string SelectedModel)
        {
            switch (SelectedModel)
            {
                case "Accord":
                    EngineVolumes.Clear();
                    EngineVolumes.Add("Меньше 3.5 литров");
                    Price += 900000;
                    VisibilityGreen = "Collapsed";
                    VisibilityYellow = "Collapsed";
                    break;
                case "CR-X":
                    WheelDrives.Clear();
                    WheelDrives.Add("Задний");
                    EnabledClimateControl = false;
                    ParkingSensorTypes.Clear();
                    ParkingSensorTypes.Add("Только сзади");
                    Price += 950000;
                    VisibilityYellow = "Collapsed";
                    break;
                case "Life":
                    EnabledClimateControl = false;
                    EnabledHeatedWheel = false;
                    EnabledRainSensor = false;
                    EnabledParkingSensor = false;
                    Price += 1000000;
                    VisibilityPink = "Collapsed";
                    VisibilityBlue = "Collapsed";
                    VisibilityGreen = "Collapsed";
                    VisibilityYellow = "Collapsed";
                    break;
                default:
                    EnabledClimateControl = false;
                    EnabledHeatedWheel = false;
                    EnabledRainSensor = false;
                    EnabledParkingSensor = false;
                    WheelDrives.Clear();
                    WheelDrives.Add("Задний");
                    Price += 790000;
                    break;
            }
        }
        public void ListsItems()
        {
            Models = new ObservableCollection<String>();
            Models.Add("Accord");
            Models.Add("CR-X");
            Models.Add("Life");
            Models.Add("S2000");

            EngineVolumes = new ObservableCollection<string>();
            EngineVolumes.Add("Меньше 3.5 литров");
            EngineVolumes.Add("Больше 3.5 литров");

            Gears = new ObservableCollection<string>();
            Gears.Add("Автоматическая");

            WheelDrives = new ObservableCollection<string>();
            WheelDrives.Add("Задний");
            WheelDrives.Add("Передний");

            ParkingSensorTypes = new ObservableCollection<string>();
            ParkingSensorTypes.Add("Только сзади");
            ParkingSensorTypes.Add("И спереди и сзади");

            EnabledClimateControl = true;
            EnabledHeatedWheel = true;
            EnabledRainSensor = true;
            EnabledParkingSensor = true;

            HasClimateControl = false;
            HasHeatedWheel = false;
            HasRainSensor = false;
            HasParkingSensor = false;

            VisibilityPink = "Visible";
            VisibilityBlue = "Visible";
            VisibilityGreen = "Visible";
            VisibilityBlack = "Visible";
            VisibilityYellow = "Visible";
        }

        public MainWindowViewModel()
        {
            ListsItems();
        }
    }
}
