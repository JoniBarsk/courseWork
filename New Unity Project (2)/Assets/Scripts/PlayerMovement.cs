using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float constantSpeed = 3f;
   public Rigidbody rb;
   private Vector3 direction;
	// Use this for initialization
	
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
	void FixedUpdate(){
        float hort = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        direction = GetUserCommand(hort, vert);
      
            transform.Translate(direction * constantSpeed);
        
        
    }
    private Vector3 GetUserCommand( float hort, float vert){
    // Input.GetAxisRaw("Horizontal")
        if (hort == 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = Vector3.forward;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = Vector3.back;
            }
        }
    // Input.GetAxisRaw("Vertical")
        if (vert == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = Vector3.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = Vector3.left;
            }
        }
        return direction;
    }

}
