using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureToWorld : MonoBehaviour
{
    public Texture2D first,after,save;
    public float xcor=0f,zcor=0f,radius=0.08f,imgmax=512;
    public Transform brush;
    public Vector3 brushpos=new Vector3(0,0,0);
    public int ycenter=0,xcenter=0,square=30;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 vct=brush.position;
        if(vct!=brushpos){
            WithRaycast();
            float bx=brush.localPosition.x,by=brush.localPosition.z;
            bx=-bx;
            by=-by;
            ChangePixel(first,after,(bx+5)/10,(by+5)/10);
            brushpos=vct;
        }

    }
    void ChangePixel(Texture2D tex2d,Texture2D paint,float kx,float ky){
        gameObject.GetComponent<Renderer>().material.mainTexture=tex2d;
        int asize=0;
        int hy=tex2d.height;
        int hx=tex2d.height;
        float sqradius=(radius*radius);
        int ystar=(int) (ky*imgmax)-ycenter;
        int xstar=(int) (kx*imgmax)-xcenter;
        for (int y = ystar-square ; y < ystar+square; y++)
        {
            float kgy=Mathf.Pow(((y/imgmax)-ky),2);
            for (int x = xstar-square; x < xstar+square; x++)
            {
                float kgx=Mathf.Pow(((x/imgmax)-kx),2);
                if( ((kgx+kgy)-sqradius)<=0 ){
                    
                    tex2d.SetPixel(x,y,paint.GetPixel(x,y));
                }
                
                asize++;
            }
        }
        Debug.Log(asize);
        tex2d.Apply();
    }
    void WithRaycast(){
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
                Debug.Log(hit.point);
                if(hit.transform.tag=="cube"){
                    Graphics.CopyTexture(save,first);
                    first.Apply();
                    save.Apply();
                    gameObject.GetComponent<Renderer>().material.mainTexture=first;
                    
                }
            }
    }
}
