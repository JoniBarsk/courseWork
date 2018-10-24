using System.IO;
using System.Text;
using System.Net;
using System;

public class PacketWriter : BinaryWriter
{
  public PacketWriter(MemoryStream input) : base(input, Encoding.UTF8)
  {

  }

  // writes an int32 (4 bytes) to the packet buffer.
  public override void Write(int value)
  {
    base.Write(IPAddress.HostToNetworkOrder(value));
  }

  // writes a string to the packet buffer.
  public override void Write(string value)
  {
    Write((short)value.Length);
    base.Write(Encoding.UTF8.GetBytes(value));
  }

  // writes an int16 (2 bytes) to the packet buffer.
  public override void Write(short value)
  {
    base.Write(IPAddress.HostToNetworkOrder(value));
  }

  // Writes the length of to the data in the right spot.
  public void WriteLength(byte[] data)
  {
    var bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data.Length));
    bytes.CopyTo(data, 1);
  }
}