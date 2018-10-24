using System;
using System.Threading.Tasks;
using Packets;

namespace NetClient
{
  class Program
  {
    static void Main(string[] args)
    {
      NetworkClient client = new NetworkClient();
      new System.Threading.Thread(async () =>
      {
        client.Connect("localhost", 2050);
        await Task.Delay(500);
        var login = new LoginPacket();
        login.Name = "Test name askldjalksdjlkajsd";
        login.Version = 12345;
        client.Send(login);
      }).Start();

      while (!client.Closed) ;
    }
  }
}
