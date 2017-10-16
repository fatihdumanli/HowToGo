using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace UlasimApp.Model
{
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUri { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }

        private BitmapImage _icon;

        public BitmapImage Image
        {
            get
            {
                if (IconUri == null)
                    return new BitmapImage();

                return _icon = _icon ?? new BitmapImage(new Uri(IconUri));
            }
        }
    }
}
