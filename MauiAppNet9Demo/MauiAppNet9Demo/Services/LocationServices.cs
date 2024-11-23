using MauiAppNet9Demo.Shared;
using MauiAppNet9Demo.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppNet9Demo.Services
{
    public class LocationServices:ILocationServices
    {
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;
       

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }

        public async Task<LocationDTO> GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    return new LocationDTO()
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                    };
                }
                else
                    return null;
                //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception ex)
            {
                // Unable to get location
                return null;
            }
            finally
            {
                _isCheckingLocation = false;
            }
            return null;
        }
    }
}
