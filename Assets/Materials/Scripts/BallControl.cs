using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public  Camera cam;
    public Transform shpr;
    public float rate=0.3f,importantz=15f,yofsphr=0.5f;
    public Vector3 offset=new Vector3(0,0,10f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            //WithRaycast();
            Vector2 mouse=Input.mousePosition;
            Vector3 a=cam.ScreenToWorldPoint(new Vector3(mouse.x,mouse.y,10.0f));
            Debug.Log("MousePos"+a);
            Vector3 temp=new Vector3(a.x,yofsphr,a.z);
            shpr.position=temp;

        }
    }
    void WithRaycast(){
        ray=cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit)){
                Debug.Log(hit.point);
                if(hit.transform.tag!="sphr"){
                    Vector3 lerppos=Vector3.Lerp(shpr.position,hit.point,rate);
                    shpr.position=lerppos;
                }
            }
    }
}
