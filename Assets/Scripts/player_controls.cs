using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
    private bool isFalling ;
    private float jumpSpeed;


    void Start()
    {
        isFalling = false;
        jumpSpeed = 3.35f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && isFalling == false) {
            Vector3 vertVelocity = GetComponent<Rigidbody>().velocity;
            vertVelocity.y = jumpSpeed;
            GetComponent<Rigidbody>().velocity = vertVelocity;

            isFalling = true;
        }    
    }

    void OnCollisionStay(Collision floor) {

        if(floor.transform.tag == "Ground") {
            isFalling = false;
        }
    }
}
