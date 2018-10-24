namespace Packets
{
  public class LoginPacket : IClientPacket
  {

    public string Name { get; set; }
    public int Version { get; set; }
    public PacketType Id
    {
      get { return PacketType.Login; }
    }

    public void Write(PacketWriter writer)
    {
      writer.Write(Name);
      writer.Write(Version);
    }
  }
}