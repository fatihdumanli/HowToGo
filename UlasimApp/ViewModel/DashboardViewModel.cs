using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlasimApp.Model;
using UlasimApp.Services.PaymentApp.Windows.Services;
using Windows.Devices.Geolocation;

namespace UlasimApp.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
      

        private Command _cmdInit;

        public Command CmdInit
        {
            get { return _cmdInit ?? new Command(Init); }
        }

        private Geopoint _hintPoint;

        public Geopoint hintPoint
        {
            get
            {
                return _hintPoint;
            }

            set
            {
                _hintPoint = value;
                base.RaisePropertyChanged(nameof(hintPoint));
            }
        }
        public async void Init()
        {
           
        }

        private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
        }

        public DashboardViewModel()
        {
        
        }

    }
}
