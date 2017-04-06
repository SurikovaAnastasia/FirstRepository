using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public List<String> Model { get; set; }
        public String SelectedModel { get; set; }

        public List<String> AmountMotor { get; set; }
        public String SelectedAmount { get; set; }

        public List<String> Transmis { get; set; }
        public String SelectedTransmis { get; set; }

        public List<String> DriveUnit { get; set; }
        public String SelectedUnit { get; set; }

        public Boolean Pink { get; set; }
        public Boolean Blue { get; set; }
        public Boolean Green { get; set; }

        public Boolean Clime { get; set; }
        public Boolean Heating { get; set; }
        public Boolean Rain { get; set; }

        private Boolean _Park;
        public Boolean Parking
        {
            get { return _Park; }
            set
            {
                _Park = value;
                DoPropertyChanged(Parking.ToString());
            }
        }
        public List<String> ParkingList { get; set; }
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

        public MainWindowViewModel()
        {
            Model = new List<string>();
            Model.Add("Accord");
            Model.Add("CR-X");
            Model.Add("Life");
            Model.Add("S2000");

            AmountMotor = new List<string>();
            AmountMotor.Add("Меньше 3.5 литров");
            AmountMotor.Add("Больше 3.5 литров");

            Transmis = new List<string>();
            Transmis.Add("Автоматическая");

            DriveUnit = new List<string>();
            DriveUnit.Add("Задний");
            DriveUnit.Add("Передний");

            ParkingList = new List<string>();
            ParkingList.Add("Только сзади");
        }
    }
}
