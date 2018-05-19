using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Bluetooth;
using Android.Net.Wifi.Aware;
using Java.IO;
using Java.Util;

namespace NotificatorApp.Service
{
    public class BluetoothService
    {
        private static BluetoothAdapter _bluetoothAdapter;
        private static BluetoothService _bluetoothService;
        private static BluetoothDevice _bluetoothDevice;
        private static BluetoothSocket _bluetoothSocket;

        private BluetoothService()
        {
        }

        public static BluetoothService GetInstance() => _bluetoothService ?? (_bluetoothService = new BluetoothService());

        public ICollection<BluetoothDevice> GetBendedDevices()
        {
            return _bluetoothAdapter.BondedDevices;
        }

        public BluetoothDevice GetBednedDeviceByName(string deviceName)
        {
            return GetBendedDevices().FirstOrDefault(x => x.Name == deviceName);
        }

        public static (bool, string) StartBluetootAdapter()
        {
            if (_bluetoothAdapter != null)
            {
                return (false, "Addapter had been started before. Cannot start another one");
            }
            _bluetoothAdapter = BluetoothAdapter.DefaultAdapter;

            if (_bluetoothAdapter == null)
            {
                return (false, "No Bluetooth adapter found");
            }

            if (!_bluetoothAdapter.IsEnabled)
            {
                _bluetoothAdapter = null;
                return (false, "Bluetooth adapter is not enabled");
            }

            return (true, "Succesfully enabled Bluetooth adapter");
        }

        public (bool, string) ConnectToDevice(string deviceName)
        {
            if (_bluetoothDevice != null)
            {
                return (false,
                    $"Cannot connect to another device. Connection to {_bluetoothDevice.Name} is alredy opened");
            }

            if (_bluetoothAdapter == null)
            {
               return (false, "Failed to find paired device. Bluetooth adapter had not been started");
            }

            _bluetoothDevice = GetBednedDeviceByName(deviceName);

            if (_bluetoothDevice == null)
            {
                return (false,
                    $"Unable to find device {deviceName} on list of paired devices. Please pair devices first.");
            }
            UUID uuid = UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");
            _bluetoothSocket = _bluetoothDevice.CreateInsecureRfcommSocketToServiceRecord(uuid);

            if (_bluetoothSocket == null)
            {
                return (false, "Unable to establish bluetooth socket");
            }

            return (true, "Device ready to connect");
        }

        public async Task OpenConnection()
        {
            await _bluetoothSocket.ConnectAsync();
        }

        public async Task SendMessage(string deviceName)
        {
            var adapterResult = StartBluetootAdapter();
            if (!adapterResult.Item1)
            {
                return;
            }

            var connectionResult = ConnectToDevice(deviceName);

            if (!connectionResult.Item1)
            {
                return;
            }

            await OpenConnection();

            if (_bluetoothSocket.IsConnected)
            {
                var mReader = new InputStreamReader(_bluetoothSocket.InputStream);
                var buffer = new BufferedReader(mReader);
            }

        }

        public Task Process(string deviceName)
        {
            Task.Run(async () => SendMessage(deviceName));
        }
    }
}