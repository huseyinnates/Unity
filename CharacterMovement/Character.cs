using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float gravity = -9.81f;
    Vector3 velocity;
    public float jump_height=3f;

    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool isground;
    public CharacterController control;
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        isground = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        Debug.Log(isground);
        if(isground && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        Vector3 move = axisX * transform.right + axisY * transform.forward;
        control.Move(move * speed * Time.deltaTime);
        print(isground);
        if (Input.GetKey(KeyCode.Q) && isground)
        {
            velocity.y = Mathf.Sqrt(jump_height * gravity * -2f);
            print("velocity"+velocity.y);
        }

        velocity.y += gravity * Time.deltaTime ;
        control.Move(velocity * Time.deltaTime);
    }
}