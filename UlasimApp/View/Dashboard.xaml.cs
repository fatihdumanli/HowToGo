using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using UlasimApp.Services;
using System.Diagnostics;
using Windows.UI.Popups;
using UlasimApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UlasimApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dashboard : Page
    {
        private BasicGeoposition queryHint;
        public Dashboard()
        {
            this.InitializeComponent();
        }

        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
        }

        private async void mapcontrol_Loaded_1(object sender, RoutedEventArgs e)
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 50 };

                    // Subscribe to the StatusChanged event to get updates of location status changes.
                    geolocator.StatusChanged += OnStatusChanged;

                    // Carry out the operation.
                    Geoposition pos = await geolocator.GetGeopositionAsync();


                    queryHint = new BasicGeoposition();
                    queryHint.Latitude = pos.Coordinate.Point.Position.Latitude;
                    queryHint.Longitude = pos.Coordinate.Point.Position.Longitude;
                    Geopoint hintPoint = new Geopoint(queryHint);
                    mapcontrol.Center = hintPoint;

                    MapIcon myPOI = new MapIcon { Location = hintPoint, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = "Your position", ZIndex = 0 };
                    mapcontrol.MapElements.Add(myPOI);
                    break;
            }
        }

        private async void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var distance = slider.Value;
            var stops = await LocationService.Instance.GetNearbyStops(queryHint.Latitude, queryHint.Longitude, distance);


            if (stops != null)
            {
                lstView.Items.Clear();

                foreach (var item in stops)
                {
                    lstView.Items.Add(new UlasimApp.ViewModel.StopViewModel()
                    {
                        Distance = 0.2,
                        IconUri = item.Line.IconUri,
                        Name = item.Name,
                        Line = item.Line
                    });

                    BasicGeoposition pos = new BasicGeoposition();
                    pos.Longitude = item.Longitude;
                    pos.Latitude = item.Latitude;
                    Geopoint point = new Geopoint(pos);

                    MapIcon myPOI = new MapIcon { Location = point, NormalizedAnchorPoint = new Point(0.5, 1.0), Title = item.Name, ZIndex = 0 };
                    mapcontrol.MapElements.Add(myPOI);
                }
            }
        }


        private void GetStopDetails()
        {


        }

     

        private async void lstView_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            MessageDialog md = new MessageDialog("fdsf");
            await md.ShowAsync();
        }
    }
}
