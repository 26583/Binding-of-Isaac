using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float currentSpeed = 0;
    [SerializeField]
    private float timeToFullSpeed = 0.1f;
    [SerializeField]
    private float timeToStop = 0.1f;
    private string dir = "none";
    private int inputAmount = 0;

    [SerializeField]
    private Animator anim;

    private void Start()
    {
        
    }

    void Update()
    {
        inputAmount = 0;
        anim.SetInteger("walkDir", 0);
        //                       Movement------------------------------------------------------------------
        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed += timeToFullSpeed;
            walk(transform.right);
            dir = "right";
            anim.SetInteger("walkDir", 4);
            inputAmount++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed += timeToFullSpeed;
            walk(-transform.right);
            anim.SetInteger("walkDir", 2);
            dir = "left";
            inputAmount++;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += timeToFullSpeed;
            walk(transform.up);
            anim.SetInteger("walkDir", 3);
            dir = "up";
            inputAmount++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed += timeToFullSpeed;
            walk(-transform.up);
            anim.SetInteger("walkDir", 1);
            dir = "down";
            inputAmount++;
        }

        // KEEPS DIAGNOL SAME SPEED
        
        //              Slow down movement ---------------------------------------------------
        
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            currentSpeed -= timeToStop;
        }
        if (currentSpeed <= 0)
        {
            currentSpeed = 0;
        }
        if (currentSpeed > 0 && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            if (dir == "right") {
                walk(transform.right);
            }
            if (dir == "left")
            {
                walk(-transform.right);
            }
            if (dir == "up")
            {
                walk(transform.up);
            }
            if (dir == "down")
            {
                walk(-transform.up);
            }
        }
        if (inputAmount > 1)
        {
            if (currentSpeed + currentSpeed >= speed)
            {
                currentSpeed = speed * 0.33333333333333f;
            }
        }
        if (currentSpeed >= speed && inputAmount <=1)
        {
            currentSpeed = speed - timeToFullSpeed;
        }
    }

    void walk(Vector3 dir)
    {
        transform.position += dir * currentSpeed * Time.deltaTime;
    }
}
