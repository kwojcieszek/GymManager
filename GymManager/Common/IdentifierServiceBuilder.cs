namespace GymManager.Common
{
    public static class IdentifierServiceBuilder
    {
        public static IdentifierService CreateFromRFIDSerialPort(SerialPortSettings serialPortSettings,
            RfidReaderConverterType rfidReaderConverterType, bool suffixCrlf, int maxLenghtData, Endianness endianness)
        {
            var dev = new IdentifierDeviceSerialPort(serialPortSettings.PortName, serialPortSettings.BaudRate,
                new RfidReaderConverter(rfidReaderConverterType, endianness), suffixCrlf, maxLenghtData);

            return new IdentifierService(dev);
        }
    }
}