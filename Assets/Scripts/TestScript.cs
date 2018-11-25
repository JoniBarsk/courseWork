using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestScript : MonoBehaviour
{

    private NetworkClient client;
    public float constantSpeed = 1f;
    private Opponent adversary;
    private Queue<IServerPacket> serverPackets;
    private Object mutex = new Object();
    private void OnDestroy()
    {
        client.Dispose();
    }
    // Use this for initialization
    void Start()
    {
        serverPackets = new Queue<IServerPacket>();
        client = new NetworkClient();
        client.Connect("localhost", 2050);
        adversary = gameObject.AddComponent<Opponent>();

        client.OnPacket += (packet) =>
        {
            lock (mutex)
            {
                serverPackets.Enqueue(packet);
            }
        };
        client.Connected += (connected) =>
        {
            if (!connected)
            {
                return;
            }
            var login = new Packets.LoginPacket();
            login.Name = "Test Client";
            login.Version = 12345;
            client.Send(login);
        };
    }
    private void Update()
    {
        IServerPacket packet = null;
        lock (mutex)
        {
            //Debug.Log(string.Format("Queue length: {0}, deltatime {1}", serverPackets.Count, Time.deltaTime));
            if (serverPackets.Count > 0)
            {
                packet = serverPackets.Dequeue();
            }
        }
        if (packet != null)
        {
            // Debug.Log(string.Format("Received Server Packet {0}", packet.Id));
            switch (packet.Id)
            {
                case PacketType.LobbyInfo:
                    var info = packet as Packets.LobbyInfoPacket;
                    Debug.Log(info.ToString());
                    if (info.PlayerInfo.Any(p => !p.Ready))
                    {
                        var reply = new Packets.LobbyUpdatePacket();
                        reply.Ready = true;
                        client.Send(reply);
                    }
                    break;
                case PacketType.LoadGame:
                    var myId = (packet as Packets.LoadGamePacket).ClientId;
                    var ack = new Packets.LoadGameAckPacket();
                    ack.ClientId = myId;
                    client.Send(ack);
                    break;
                case PacketType.Tick:
                    // str: Players: ID: 0, Pos:(float, float), Direction: Right, 
                    // Id: 1, Pos (float, float), direction: Right, ...
<<<<<<< HEAD
                    // Debug.Log("Case Tick");
                    adversary.ReceiveCommand(packet as Packets.TickPacket);
                    Debug.Log(packet.ToString());
=======
                    adversary.OnTick(packet as Packets.TickPacket);
>>>>>>> 5e686902e295582cf75428148d38f08acfac7c6f
                    break;
                default:
                    // Debug.Log("Default");
                    Debug.Log(string.Format("Type: {0}, str: {1}", packet.Id, packet.ToString()));
                    break;
            }
        }
    }
}
