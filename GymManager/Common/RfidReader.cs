namespace GymManager.Common;

public class RfidReader
{
    public Endianness Endianness { get; set; } = Endianness.BigEndian;

    public int MaxLenghtData { get; set; } = 255;
    public RfidReaderConverterType RfidReaderConverterType { get; set; } = RfidReaderConverterType.HexToInt;
    public bool SuffixCRLF { get; set; } = true;
}