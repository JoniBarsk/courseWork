using Packets;
public static class PacketResolver
{
  public static IServerPacket Create(PacketType type)
  {
    switch (type)
    {
      case PacketType.Failure: return new FailurePacket();
      case PacketType.LobbyInfo: return new LobbyInfoPacket();
    }
    return null;
  }
}