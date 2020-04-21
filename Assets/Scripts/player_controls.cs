using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
    private bool isFalling ;
    private float jumpSpeed, walkSpeed;

    private bool isForward, isBack, isLeft, isRight, isJump;


    void Start()
    {
        isForward = false;
        isBack = false;
        isLeft = false;
        isRight = false;
        isFalling = false;
        jumpSpeed = 3.35f;
        walkSpeed = 3.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isForward == true) {
            GetComponent<Rigidbody>().velocity = transform.forward * walkSpeed;
        }

        if (this.isBack == true) {
            GetComponent<Rigidbody>().velocity = -transform.forward * walkSpeed;
        }

        if (this.isLeft == true) {
            GetComponent<Rigidbody>().velocity = -transform.right * walkSpeed;
        }

        if (this.isRight == true) {
            GetComponent<Rigidbody>().velocity = transform.right * walkSpeed;
        }
    }

    public void onJumpBtn()
    {
        if (isFalling == false) {
            Vector3 vertVelocity = GetComponent<Rigidbody>().velocity;
            vertVelocity.y = jumpSpeed;
            GetComponent<Rigidbody>().velocity = vertVelocity;

            isFalling = true;
        }
    }

    public void onForwardDown()
    {
        this.isForward = true;
    }

    public void onForwardUp()
    {
        this.isForward = false;
    }

    public void onLeftDown()
    {
        this.isLeft = true;
    }

    public void onLeftUp()
    {
        this.isLeft = false;
    }

    
    public void onRightDown()
    {
        this.isRight = true;
    }

    public void onRightUp()
    {
        this.isRight = false;
    }

    public void onBackDown()
    {
        this.isBack = true;
    }

    public void onBackUp()
    {
        this.isBack = false;
    }

    void OnCollisionStay(Collision floor) {

        if(floor.transform.tag == "Ground") {
            isFalling = false;
        }
    }
}
