using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Opponent : MonoBehaviour {

    public GameObject opponentsPrefab;
    private List<IDGenerator> oppGameObjects;
    public float constantSpeed = 1f;

    void Start(){
        if(oppGameObjects == null){
            oppGameObjects = new List<IDGenerator>();
            Debug.Log("gameobjects[]: " + oppGameObjects);
        }
    }
    // void Update(){}


    public void OnTick(Packets.TickPacket tickPacketInfo){
        var orders = tickPacketInfo.Players;
        foreach (var order in orders)
        {
            int id = order.Id;
            var pos = order.Position;
            var dir = order.Direction;
            bool idExists = false;
            if(oppGameObjects != null && oppGameObjects.Count != 0){
            for(int i = 0; i <= orders.Length-1; i++){
                // Debug.Log("i: " + i);
                // Debug.Log("count: " + oppGameObjects.Count);
                if(oppGameObjects.Count > i){
                        IDGenerator idnum = oppGameObjects[i].GetComponent<IDGenerator>();
                        // Debug.Log(string.Format("orderID: {0}, IDNumber: {1}", order.Id, idnum.idNumber));
                        if (order.Id == idnum.idNumber)
                        {
                            idExists = true;
                        }
                }

            }}
            // Debug.Log("Does it exist: " + idExists + " -:- " + id);
            if(idExists){
 
                    for (int i = 0; i <= oppGameObjects.Count-1; i++)
                    {
                    IDGenerator num = oppGameObjects[i].GetComponent<IDGenerator>();
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
                                    break;
                            }
                            oppGameObjects[i].transform.Translate(newDir * constantSpeed);
                            // oppGameObjects[i].transform.position = Vector3.MoveTowards(transform.position, pos, 3f * Time.deltaTime);

                        }
                    }
                idExists = false;
            }
            else{

                GameObject newOpponent = Instantiate(Resources.Load("opponentPrefab"), pos, Quaternion.identity) as GameObject;
                IDGenerator newOpponentObject = newOpponent.GetComponent<IDGenerator>();
                Debug.Log("Generate Opponent: " + id);
                newOpponentObject.idNumber = id;
                oppGameObjects.Add(newOpponentObject);
            }
        }
    }
    
}
