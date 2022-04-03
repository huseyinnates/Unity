using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    public Texture2D first,after;
    public GameObject assign;
    Vector3 holder=new Vector3(0,0,0);
    void Start(){

        //ChangePixel(first,after);
        
    }
    void Update(){
       
    }
    void OnCollisionStay(Collision col){
       
       Debug.Log(col.gameObject.name);
       Vector3 pos=new Vector3(0,0,0);
       pos=col.transform.position;
       if(holder!=pos){
           ChangePixel(first,after,pos.z,pos.x);
            holder=col.transform.position;
       }
      
       
    }
   
    void ChangePixel(Texture2D tex2d,Texture2D paint,float kx,float ky){
        assign.GetComponent<Renderer>().material.mainTexture=tex2d;
        int asize=0;
        kx*=15;
        ky*=35;
        for (int y = 0; y < tex2d.height; y++)
        {
            for (int x = 0; x < tex2d.width; x++)
            {
                if(kx>(y/512) && ky>(x/512) && kx<(y/512) && ky<(x/512)){
                    tex2d.SetPixel(x,y,paint.GetPixel(x,y));
                
                }
                asize++;
            }
        }
        Debug.Log(asize);
        tex2d.Apply();
    }
}