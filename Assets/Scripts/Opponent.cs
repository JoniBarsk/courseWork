using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour {
 
    private GameObject[] opponents;
    public float constantSpeed = 1f;
    // Use this for initialization
    void Start(){
        opponents = GameObject.FindGameObjectsWithTag("Opponent");
       
        for(int i = opponents.Length-1; i >= 0; i--){
            IDGenerator idgen = opponents[i].GetComponent<IDGenerator>();
            idgen.idNumber = i;
        }}


         public void ReceiveCommand(Packets.TickPacket tickPacketInfo)
        {
        var orders = tickPacketInfo.Players;
        foreach (Packets.PlayerInfo order in orders)
        {
            int id = order.Id;
            var pos = order.Position;
            var dir = order.Direction;
            for(int i =0; i < opponents.Length; i++){
                IDGenerator num = opponents[i].GetComponent<IDGenerator>();
            if (id == num.idNumber)
            {
                Debug.Log("Received orders for " + id + dir);
                var direction = dir.ToString();
                Vector3 newDir = new Vector3(0, 0, 0);
                switch (direction)
                {
                    case "Up":
                        newDir = new Vector3(0, 0, 1);
                        break;
                    case "Right":
                        newDir = new Vector3(1, 0, 0);
                        break;
                    case "Left":
                        newDir = new Vector3(-1, 0, 0);
                        break;
                    case "Down":
                        newDir = new Vector3(0, 0, -1);
                        break;
                    default:
                        Debug.Log("weep");
                        break;
                }

                opponents[i].transform.Translate(newDir * constantSpeed);

                }
            }
       }
        return;
    }
}
