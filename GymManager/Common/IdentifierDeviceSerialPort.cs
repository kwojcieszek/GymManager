using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using GodSharp.SerialPort;

namespace GymManager.Common
{
    public class IdentifierDeviceSerialPort : IIdentifierDevice
    {
        public event EventHandler<EventArgsIdentifier> IdentifierReceived;
        public event EventHandler<EventArgsStatus> StateChanged;

        private const int lastKeyTimeoutMilisecound = 1000;
        private const int recivedTimeoutMilisecound = 500;
        private bool _isError;
        private bool _isStarted;
        private string _lastKey;
        private readonly int _maxLenghtData;
        private readonly RfidReaderConverter _readerConverter;
        private readonly List<byte> _recivedData = new();
        private readonly GodSerialPort _serialDevice;
        private Task _startTask;
        private readonly bool _suffixCrlf;
        private long _timeLastKey;
        private long _timeRecivedLastData;

        public IdentifierDeviceSerialPort(string portName, int baudRate, RfidReaderConverter readerConverter,
            bool suffixCrlf, int maxLenghtData)
        {
            _readerConverter = readerConverter;
            _maxLenghtData = maxLenghtData;
            _suffixCrlf = suffixCrlf;

            _serialDevice = new GodSerialPort(portName, baudRate, 0);
        }

        public void Start()
        {
            if(_isStarted)
            {
                return;
            }

            _isStarted = true;

            _startTask = new Task(() =>
            {
                while(_isStarted)
                {
                    try
                    {
                        if(!_serialDevice.IsOpen || _isError)
                        {
                            _serialDevice.Open();

                            if(_serialDevice.IsOpen)
                            {
                                StateChanged?.Invoke(this, new EventArgsStatus(new StatusDevice(string.Empty, true)));

                                _isError = false;
                            }
                            else
                            {
                                StateChanged?.Invoke(this,
                                    new EventArgsStatus(new StatusDevice(
                                        $"BŁĄD OTWARCIA PORTU {_serialDevice.PortName}",
                                        false)));
                            }
                        }

                        if(_serialDevice.IsOpen)
                        {
                            DataReceived(_serialDevice.Read());
                        }

                        Thread.Sleep(50);
                    }
                    catch(Exception ex)
                    {
                        _isError = true;

                        Debug.WriteLine(ex.Message);

                        Logger.Log.Error(ex);

                        StateChanged?.Invoke(this, new EventArgsStatus(new StatusDevice(ex.Message, false)));
                    }
                }
            });

            _startTask.Start();
        }

        public void Stop()
        {
            _isStarted = false;

            _startTask?.Wait();
        }

        private void DataReceived(byte[] recivedData)
        {
            if(recivedData != null && recivedData.Length > 0 && _recivedData.Count > 0 &&
               new TimeSpan(DateTime.Now.Ticks - _timeRecivedLastData).TotalMilliseconds > recivedTimeoutMilisecound)
            {
                _recivedData.Clear();
            }

            if(recivedData != null && recivedData.Length > 0)
            {
                _recivedData.AddRange(recivedData);
                _timeRecivedLastData = DateTime.Now.Ticks;
            }
            else
            {
                return;
            }

            if(_recivedData.Count > _maxLenghtData)
            {
                _recivedData.Clear();

                return;
            }

            string keyString = null;

            if(_suffixCrlf)
            {
                if(IsCrlf(_recivedData))
                {
                    keyString = _readerConverter.Convert(_readerConverter.RemoveCrlf(_recivedData.ToArray()));
                }
            }
            else
            {
                keyString = _readerConverter.Convert(_recivedData.ToArray());
            }

            if(keyString == null)
            {
                return;
            }

            _recivedData.Clear();

            if(keyString == _lastKey && new TimeSpan(DateTime.Now.Ticks - _timeLastKey).TotalMilliseconds <
               lastKeyTimeoutMilisecound)
            {
                return;
            }

            _timeLastKey = DateTime.Now.Ticks;

            _lastKey = keyString;

            IdentifierReceived?.Invoke(this, new EventArgsIdentifier(keyString));
        }

        private bool IsCrlf(List<byte> data)
        {
            return data[data.Count - 2] == 0x0d && data[data.Count - 1] == 0x0a ? true : false;
        }
    }
}