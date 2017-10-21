using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlasimApp.Model;
using UlasimApp.Services.PaymentApp.Windows.Services;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace UlasimApp.ViewModel
{
    public class StopViewModel
    {

      

        public string Name { get; set; }
        public string IconUri { get; set; }
        private BitmapImage _icon;
        public Line Line { get; set; }

        public BitmapImage Image
        {
            get
            {
                if (IconUri == null)
                    return new BitmapImage();

                return _icon = _icon ?? new BitmapImage(new Uri(IconUri));
            }
        }


        public double Distance { get; set; }

    }
}
