using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Google.Maps.Geocoding;
using Google.Maps.StaticMaps;
using Google.Maps;
using Divvy;
using BikeSharing;
using Google.Maps.DistanceMatrix;
using System.Device.Location;
using System.Linq;
using System.Collections.Generic;
using ActiveCommute.Navigator;

namespace SearchAddressMap
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}

        IReadOnlyList<Ilocation>  nearestStations;
		private void refreshMap()
		{
			if (resultsTreeView.SelectedItem == null) return;

			var location = ((LatLng)((TreeViewItem)resultsTreeView.SelectedItem).Tag);
			var map = new StaticMapRequest();
			map.Center = location;
			map.Zoom = Convert.ToInt32(zoomSlider.Value);
			map.Size = new System.Drawing.Size(332, 332);
			map.Markers.Add(map.Center);
            foreach (Ilocation bikeStation in nearestStations)
            {
                map.Markers.Add(new LatLng(bikeStation.Latitude, bikeStation.Longitude));
            }
			map.MapType = (MapTypes)Enum.Parse(typeof(MapTypes), ((ComboBoxItem)mapTypeComboBox.SelectedItem).Content.ToString(),true);
			map.Sensor = false;

			var image = new BitmapImage();
			image.BeginInit();
			image.CacheOption = BitmapCacheOption.OnDemand;
			image.UriSource = map.ToUri();
			image.DownloadFailed += new EventHandler<ExceptionEventArgs>(image_DownloadFailed);
			image.EndInit();
			image1.Source = image;
		}

		void image_DownloadFailed(object sender, ExceptionEventArgs e)
		{
			MessageBox.Show(e.ErrorException.Message, "Couldn't retrieve map");
		}

		private void searchButton_Click(object sender, RoutedEventArgs e)
		{
			var request = new GeocodingRequest();
			request.Address = searchTextBox.Text;
			request.Sensor = false;
			var response = new GeocodingService().GetResponse(request);

			if (response.Status == ServiceResponseStatus.Ok)
			{
				resultsTreeView.ItemsSource = response.Results.ToTree();
			}

            //var t = (new Divvy.DivvySystem()).GetAllStationInformation;
		}

		private void resultsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
            LatLng location = ((LatLng)((TreeViewItem)resultsTreeView.SelectedItem).Tag);
            Ilocation currentLoc = new Loc(location.Latitude, location.Longitude);

            Navigator nav = new Navigator("chicago");
            nearestStations = nav.GetShortestPath(currentLoc, new Loc(41.883589, -87.636392));

            //List<IBikeStation> ns = new List<IBikeStation>();
            //var stationList = ((new Divvy.DivvySystem()).GetAllStationInformation);
            //foreach(IBikeStation st in stationList)
            //{
            //    if (st.Location.GetDistanceTo(currentLoc) < 10000)
            //    {
            //        ns.Add(st);
            //    }
            //}
            ////nearestStations = .OrderByDescending(item => item.Location.GetDistanceTo(currentLoc)).TakeWhile(item => item.Location.GetDistanceTo(currentLoc) < 13500).ToArray();
            //nearestStations = ns.OrderByDescending(item => item.Location.GetDistanceTo(currentLoc)).Take(20).ToArray();
            //double t = nearestStations[0].Location.GetDistanceTo(currentLoc);

            //DistanceMatrixService s = new DistanceMatrixService();
            //DistanceMatrixRequest req =  new DistanceMatrixRequest();
            //req.Mode = TravelMode.bicycling;
            //req.Sensor = false;

            //req.AddOrigin(new Waypoint((decimal)location.Latitude, (decimal)location.Longitude));
            //int i = 1;
            //foreach (IBikeStation bikestation in nearestStations)
            //{
            //    req.AddDestination(new Waypoint((decimal)bikestation.Location.Latitude, (decimal)bikestation.Location.Longitude));
            //    if(++i > 5)
            //        break;

            //}

            ////GoogleSigned gsigned = new GoogleSigned("358748183389-dpat5u90dsuv6ojgk10o5o6occ8c8kc6.apps.googleusercontent.com", "74058d5809b9672c7c6ee55cab7a8b21bb26b4be");
            ////GoogleSigned.AssignAllServices(gsigned);

            //var response = s.GetResponse(req);
            refreshMap();
		}

		private void zoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (zoomLabel != null)
			{
				zoomLabel.Content = zoomSlider.Value.ToString("0x");
				refreshMap();
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			zoomLabel.Content = zoomSlider.Value.ToString("0x");
		}

		private void mapTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			refreshMap();
		}
	}
}
