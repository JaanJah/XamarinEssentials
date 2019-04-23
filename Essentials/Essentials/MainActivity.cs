using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;

namespace Essentials
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Assign Xamarin Essentials to TextViews
            AssignInfo();

            //Handle info changes
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            GetDisplayInfo();
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            GetNetworkInfo();
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            GetBatteryInfo();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void AssignInfo()
        {
            GetAppInfo();
            GetBatteryInfo();
            GetNetworkInfo();
            GetDisplayInfo();
            GetDeviceInfo();
        }

        private void GetAppInfo()
        {
            var appName = AppInfo.Name;
            var appNameText = FindViewById<TextView>(Resource.Id.appName);
            appNameText.Text = "App name: " + appName;
        }

        private void GetBatteryInfo()
        {
            var chargeLevel = Battery.ChargeLevel;
            var chargeLevelText = FindViewById<TextView>(Resource.Id.chargeLevel);
            chargeLevelText.Text = "Battery charge level: " + chargeLevel;
        }

        private void GetNetworkInfo()
        {
            var networkAccess = Connectivity.NetworkAccess;
            var networkAccessText = FindViewById<TextView>(Resource.Id.networkAccess);
            networkAccessText.Text = "Network access: " + networkAccess;
        }

        private void GetDisplayInfo()
        {
            var displayDensity = DeviceDisplay.MainDisplayInfo.Density;
            var displayDensityText = FindViewById<TextView>(Resource.Id.displayDensity);
            displayDensityText.Text = "Display density: " + displayDensity;
        }

        private void GetDeviceInfo()
        {
            var devicePlatform = DeviceInfo.Platform;
            var devicePlatformText = FindViewById<TextView>(Resource.Id.devicePlatform);
            devicePlatformText.Text = "Device platform: " + devicePlatform;
        }
    }
}