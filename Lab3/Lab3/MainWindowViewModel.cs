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
        public Int32 PriceAccord = 900000;
        public Int32 PriceCRX = 900000;
        public Int32 PriceLife = 900000;
        public Int32 PriceS2000 = 900000;

        public Int32 PriceMinVolumes = 30000;
        public Int32 PriceMaxVolumes = 60000;

        public Int32 PriceGear = 20000;

        public Int32 PriceWheelTop = 300000;
        public Int32 PriceWheelBottom = 400000;

        public Int32 PriceClimateControl = 10000;
        public Int32 PriceHeatedWheel = 9000;
        public Int32 PriceRainSensor = 12500;

        public Int32 PriceParkingSensorBottom = 3000;
        public Int32 PriceParkingSensorTopBottom = 9000;

        public ObservableCollection<string> Models { get; private set; }
        private String _SelectedModel;
        public String SelectedModel
        {
            get { return _SelectedModel; }
            set
            {
                _SelectedModel = value;
                ListsItems();
                SelectModel(Models, _SelectedModel);
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

        public Int32 Price { get; set; }

        public ICommand Calculate { get; set; }       
        public ICommand Cancel { get; set; }

        private bool _HasClimateControl;
        public bool HasClimateControl
        {
            get { return _HasClimateControl; }
            set
            {
                _HasClimateControl = value;
                DoPropertyChanged(nameof(HasClimateControl));
            }
        }
        private bool _HasHeatedWheel;
        public bool HasHeatedWheel
        {
            get { return _HasHeatedWheel; }
            set
            {
                _HasHeatedWheel = value;
                DoPropertyChanged(nameof(HasHeatedWheel));
            }
        }
        private bool _HasRainSensor;
        public bool HasRainSensor
        {
            get { return _HasRainSensor; }
            set
            {
                _HasRainSensor = value;
                DoPropertyChanged(nameof(HasRainSensor));
            }
        }
        private bool _HasParkingSensor;
        public bool HasParkingSensor
        {
            get { return _HasParkingSensor; }
            set
            {
                _HasParkingSensor = value;
                DoPropertyChanged(nameof(HasParkingSensor));
            }
        }

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

        public void SelectModel(ObservableCollection<String> Models, string SelectedModel)
        {
            switch (SelectedModel)
            {
                case "Accord":
                    EngineVolumes.Clear();
                    EngineVolumes.Add("Меньше 3.5 литров");
                    VisibilityGreen = "Collapsed";
                    VisibilityYellow = "Collapsed";
                    break;
                case "CR-X":
                    WheelDrives.Clear();
                    WheelDrives.Add("Задний");
                    EnabledClimateControl = false;
                    ParkingSensorTypes.Clear();
                    ParkingSensorTypes.Add("Только сзади");
                    VisibilityYellow = "Collapsed";
                    break;
                case "Life":
                    EnabledClimateControl = false;
                    EnabledHeatedWheel = false;
                    EnabledRainSensor = false;
                    EnabledParkingSensor = false;
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

            HasClimateControl = false;
            HasHeatedWheel = false;
            HasRainSensor = false;
            HasParkingSensor = false;

            EnabledClimateControl = true;
            EnabledHeatedWheel = true;
            EnabledRainSensor = true;
            EnabledParkingSensor = true;

            VisibilityPink = "Visible";
            VisibilityBlue = "Visible";
            VisibilityGreen = "Visible";
            VisibilityBlack = "Visible";
            VisibilityYellow = "Visible";

            Price = 0;
            Pink = true;
        }

        public MainWindowViewModel()
        {
            ListsItems();
        }
    }
}
