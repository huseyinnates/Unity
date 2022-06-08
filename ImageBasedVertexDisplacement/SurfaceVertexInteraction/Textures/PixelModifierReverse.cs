using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelModifierReverse : MonoBehaviour
{
   public GameObject CanvasUI;
   public Texture2D first,after;
  public GameObject assign ;
    public int int1=100,int2=200;
    int asize=0;
   void Start(){
       Screen.SetResolution(1920,1080,true);
   }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit)) {
                    Vector3 converted=Camera.main.WorldToScreenPoint(hit.point);
                   // Debug.Log("CONVERTED TO SCREEN "+converted);
                    if(converted.y<715 &&  converted.y>200){//515
                        if(converted.x<1830 &&  converted.x>1300){//530
                         ChangePixel(first,after,converted.y-200,512-converted.x-1300);
                         //Debug.Log("WORKING");
                    }
                    }
            }
        }
        if(asize>200_000){
            Debug.Log("You Passed this level");
            CanvasUI.SetActive(true);
        }
    }

    
    
    void ChangePixel(Texture2D tex2d,Texture2D paint,float kx,float ky){
        assign.GetComponent<Renderer>().material.SetTexture("_MainTex",tex2d);
        for (float y = 0; y < 50; y++)
        {
            for (float x = 0; x < 50; x++)
            {
                Color pixelcolor=tex2d.GetPixel((int)(kx+x),(int)(ky+y));
                if(pixelcolor!=Color.white){
                    tex2d.SetPixel((int)(kx+x),(int)(ky+y),Color.white);
                    asize++;
                }
            }
        }
       // Debug.Log(asize);
        tex2d.Apply();
    }

}
