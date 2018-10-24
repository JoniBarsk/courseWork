using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectScript : MonoBehaviour {
	private NetworkClient client;
	// Use this for initialization
	void Start () {
        client = new NetworkClient();
        client.Connect("localhost", 2050);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
