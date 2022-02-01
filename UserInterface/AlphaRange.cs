using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaRange : MonoBehaviour
{
    public Image blood;
    public float bloodanimtime=3f;
    // Start is called before the first frame update
    void Start()
    {
        blood.CrossFadeAlpha(0,0,false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")){
            blood.enabled=true;
            blood.CrossFadeAlpha(1,bloodanimtime,false);    
        }
         if(Input.GetButton("Fire2")){
            blood.CrossFadeAlpha(0,bloodanimtime,false);
        }
       

    }
}
