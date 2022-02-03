using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicContol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Input.GetAxis("Horizontal")*10,0,Input.GetAxis("Vertical")*10);
    }
}
