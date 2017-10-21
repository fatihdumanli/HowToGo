using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlasimApp.Model;
using UlasimApp.Services;
using UlasimApp.Services.PaymentApp.Windows.Services;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace UlasimApp.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {

        private Line _line;

        public Line Line
        {
            get
            {
                return _line;
            }

            set
            {
                _line = value;
                base.RaisePropertyChanged(nameof(Line));
            }
        }
        private bool _isPopupOpen;

        public bool IsPopupOpen
        {
            get
            {
                return _isPopupOpen;
            }

            set
            {
                _isPopupOpen = value;
                base.RaisePropertyChanged(nameof(IsPopupOpen));
            }
        }

        private Command<StopViewModel> _cmdStopClick;

        public Command<StopViewModel> CmdStopClick
        {
            get { return _cmdStopClick ?? new Command<StopViewModel>(CmdStopClick2); }
        }

        private async void CmdStopClick2(StopViewModel o)
        {
            IsPopupOpen = true;
            Line = o.Line;
        }

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
            var user = AccountService.Instance.User;
        }

        private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
        }

        public DashboardViewModel()
        {
        
        }

    }
}
