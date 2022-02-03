using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Creator : MonoBehaviour
{
    GameObject general,creat,baseray,cursor,creatoritself;
    public GameObject brick;
    Transform pos;
    LayerMask wall;
    bool stopper=false;
    float angular=10f;
    Ray ray;
    RaycastHit hit;
    PhotonView mineview;
    float mousex=0,mousey=0;
    // Start is called before the first frame update
    void Start()
    {
        wall= LayerMask.GetMask("wall");
        mineview=gameObject.GetComponent<PhotonView>();
        general=GameObject.Find("MainCamera");
        creat=GameObject.Find("Camera");
        baseray=GameObject.Find("base");
        cursor=GameObject.Find("cursor");
        creatoritself=GameObject.Find("CreatorGun");
        pos=GameObject.Find("trigger").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mineview.IsMine){
            ray=new Ray(baseray.transform.position,baseray.transform.forward);
        if(Physics.Raycast(ray,out hit)){
            cursor.transform.position=hit.point;
        }
        float distance=Vector3.Distance(pos.position,transform.position);
        Debug.Log(distance);
        if(distance<2){
            mousex+=Input.GetAxis("Mouse X")*Time.deltaTime*angular;
            mousey+=Input.GetAxis("Mouse Y")*Time.deltaTime*angular;
            mousey=Mathf.Clamp(mousey,-90,90);

		  creatoritself.transform.localRotation = Quaternion.AngleAxis(mousex, Vector3.up);
		  creatoritself.transform.localRotation*=Quaternion.AngleAxis(mousey, Vector3.left);
            if(Input.GetKey(KeyCode.Q)){
                GameObject.Find("Camera").GetComponent<Camera>().enabled=true;
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled=false;
                stopper=true;
                Debug.Log("WOFASDGDDDDDDDDDDDDD");
            }
            else if(Input.GetKey(KeyCode.E)){
                GameObject.Find("Camera").GetComponent<Camera>().enabled=false;
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled=true;
                stopper=false;
                Debug.Log("CCCCCCCCCCCCCCCCCC");
            }
            if(Input.GetButton("Fire1")){
                PhotonNetwork.Instantiate(brick.name,cursor.transform.position,Quaternion.identity);
            }
            if(stopper){
                gameObject.GetComponent<Rigidbody>().velocity=Vector3.zero;
            }
        }

        }
        
    }

}
