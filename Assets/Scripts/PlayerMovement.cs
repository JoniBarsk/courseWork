using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float constantSpeed = 1f;
    private Rigidbody rb;
    private Vector3 direction;
   void Start(){
       rb = GetComponent<Rigidbody>();
   }
	void Update(){
        // Debug.Log("fixedUpdate");
        float hort = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        var oldDir = direction;
        direction = GetUserCommand(hort, vert, oldDir);
        rb.transform.Translate(direction * constantSpeed);
    }
    private Vector3 GetUserCommand( float hort, float vert, Vector3 olddir){
        // Input.GetAxisRaw("Horizontal")
        // Debug.Log(hort + " hort");
        // Debug.Log(vert + " vert");
        if (hort == 0)
        {
            if (Input.GetKey(KeyCode.UpArrow) && olddir != Vector3.back)
            {
                direction = Vector3.forward;
            }
            if (Input.GetKey(KeyCode.DownArrow) && olddir != Vector3.forward)
            {
                direction = Vector3.back;
            }
        }
        // Input.GetAxisRaw("Vertical")
        if (vert == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow) && olddir != Vector3.left)
            {
                direction = Vector3.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && olddir != Vector3.right)
            {
                direction = Vector3.left;
            }
        }
        return direction;
    }

}