using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayIamChanged : MonoBehaviour
{
    public static bool MyPositionChanged=false;
    // Update is called once per frame
    Vector3 firstpos;
    void Start(){
        firstpos=transform.position;
    }
    void Update()
    {
        if(firstpos!=transform.position){
            MyPositionChanged=true;
            firstpos=transform.position;
        }
    }
}
