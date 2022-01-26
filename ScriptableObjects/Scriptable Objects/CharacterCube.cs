using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCube : MonoBehaviour
{
    public Scriptableobjects obj;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>().name=obj.charactername;
        this.GetComponent<Transform>().position+=obj.pos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")){
            this.GetComponent<Transform>().position+=obj.pos;
        }
         if(Input.GetButton("Fire2")){
            this.GetComponent<Transform>().position-=obj.pos;
        }
    }
}
