namespace Packets
{
    public class LobbyInfoPacket : IServerPacket
    {
        public PacketType Id
        {
            get { return PacketType.LobbyInfo; }
        }

        public PlayerInfo[] PlayerInfo { get; set; }

        public void Read(PacketReader reader)
        {
            PlayerInfo = new PlayerInfo[reader.ReadInt16()];
            for (int i = 0; i < PlayerInfo.Length; i++)
            {
                PlayerInfo[i] = new PlayerInfo();
                PlayerInfo[i].Read(reader);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var info in PlayerInfo)
            {
                str += info + ", ";
            }
            return str;
        }
    }
}