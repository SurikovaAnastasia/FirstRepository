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

namespace Lab3
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<String> Model { get; set; }
        private String _sm;
        public String SelectedModel
        {
            get { return _sm; }
            set
            {
                _sm = value;
                ListsItems();
                SelectModel(Model, _sm);
                DoPropertyChanged(_sm);
            }
        }

        public ObservableCollection<String> AmountMotor { get; set; }
        public String SelectedAmount { get; set; }

        public ObservableCollection<String> Transmis { get; set; }
        public String SelectedTransmis { get; set; }

        public ObservableCollection<String> DriveUnit { get; set; }
        public String SelectedUnit { get; set; }

        public Boolean Pink { get; set; }
        public Boolean Blue { get; set; }
        public Boolean Green { get; set; }
        public Boolean Black { get; set; }
        public Boolean Yellow { get; set; }

        public String EnPink { get; set; }
        public String EnBlue { get; set; }
        public String EnGreen { get; set; }
        public String EnBlack { get; set; }
        public String EnYellow { get; set; }

        public Boolean Clime { get; set; }
        public Boolean ClEn { get; set; }
        public Boolean Heating { get; set; }
        public Boolean HeaEn { get; set; }
        public Boolean Rain { get; set; }
        public Boolean RaEn { get; set; }

        private Boolean _Park;
        public Boolean ParkEn { get; set; }
        public Boolean Parking
        {
            get { return _Park; }
            set
            {
                _Park = value;
                DoPropertyChanged(_Park.ToString());
            }
        }
        public ObservableCollection<String> ParkingList { get; set; }
        public String SelectedPark { get; set; }

        public Double Price { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }

        public void SelectModel(ObservableCollection<string> ModelList, string SelectedModel)
        {
            switch (SelectedModel)
            {
                case "Accord":
                    AmountMotor.Clear();
                    AmountMotor.Add("Меньше 3.5 литров");
                    Price += 900000;
                    EnGreen = "Collapsed";
                    EnYellow = "Collapsed";
                    break;
                case "CR-X":
                    DriveUnit.Clear();
                    DriveUnit.Add("Задний");
                    ClEn = false;
                    ParkingList.Clear();
                    ParkingList.Add("Только сзади");
                    Price += 950000;
                    EnYellow = "Collapsed";
                    break;
                case "Life":
                    ClEn = false;
                    HeaEn = false;
                    RaEn = false;
                    ParkEn = false;
                    Parking = false;
                    Price += 1000000;
                    EnPink = "Collapsed";
                    EnBlue = "Collapsed";
                    EnGreen = "Collapsed";
                    EnYellow = "Collapsed";
                    break;
                default:
                    ClEn = false;
                    HeaEn = false;
                    RaEn = false;
                    ParkEn = false;
                    Parking = false;
                    DriveUnit.Clear();
                    DriveUnit.Add("Задний");
                    Price += 790000;
                    break;
            }
        }
        public void ListsItems()
        {
            Model = new ObservableCollection<string>();
            Model.Add("Accord");
            Model.Add("CR-X");
            Model.Add("Life");
            Model.Add("S2000");

            AmountMotor = new ObservableCollection<string>();
            AmountMotor.Add("Меньше 3.5 литров");
            AmountMotor.Add("Больше 3.5 литров");

            Transmis = new ObservableCollection<string>();
            Transmis.Add("Автоматическая");

            DriveUnit = new ObservableCollection<string>();
            DriveUnit.Add("Задний");
            DriveUnit.Add("Передний");

            ParkingList = new ObservableCollection<string>();
            ParkingList.Add("Только сзади");
            ParkingList.Add("И спереди и сзади");

            ClEn = true;
            HeaEn = true;
            RaEn = true;
            ParkEn = true;

            EnPink = "Visible";
            EnBlue = "Visible";
            EnGreen = "Visible";
            EnBlack = "Visible";
            EnYellow = "Visible";
        }

        public MainWindowViewModel()
        {
            ListsItems();
        }
    }
}
