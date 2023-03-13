using System;
using System.Text;
using GymManager.Common.Extensions;

namespace GymManager.Common
{
    public class RfidReaderConverter
    {
        private readonly Endianness _endianness;
        private readonly RfidReaderConverterType _rfidReaderConverterType;

        public string Convert(byte[] data)
        {
            if (_rfidReaderConverterType == RfidReaderConverterType.TextToHexToInt)
            {
                return TextToHexToInt(data);
            }

            if (_rfidReaderConverterType == RfidReaderConverterType.HexToInt)
            {
                return HexToInt(data);
            }

            return null;
        }

        public byte[] RemoveCrlf(byte[] data)
        {
            if (data.Length > 1 && data[^2] == 0x0d && data[^1] == 0x0a)
            {
                var newData = new byte[data.Length - 2];
                Array.Copy(data, newData, data.Length - 2);

                return newData;
            }

            return data;
        }

        private byte[] EndiannessConverter(byte[] data)
        {
            if (BitConverter.IsLittleEndian && _endianness == Endianness.BigEndian)
            {
                Array.Reverse(data);
            }

            return data;
        }

        private string HexToInt(byte[] data)
        {
            if (data.Length > 8)
            {
                throw new ArgumentOutOfRangeException();
            }

            var convertData = new byte[8];

            data.CopyTo(convertData, 0);

            return BitConverter.ToUInt64(EndiannessConverter(convertData)).ToString();
        }

        private string TextToHexToInt(byte[] data)
        {
            var bytes = Encoding.ASCII.GetString(data).ToByteArray(8);

            return BitConverter.ToInt64(EndiannessConverter(bytes)).ToString();
        }

        public RfidReaderConverter(RfidReaderConverterType rfidReaderConverterType, Endianness endianness)
        {
            _rfidReaderConverterType = rfidReaderConverterType;
            _endianness = endianness;
        }
    }
}