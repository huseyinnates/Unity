using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Explosion : MonoBehaviour
{
    public float _radius=10f,_maxdistance=20f,explosionpower=400f;
    public LayerMask _layermask;
    RaycastHit _hit;
    public GameObject bulletobj;
    public TextMeshProUGUI fps;
    void Start(){
        Application.targetFrameRate=60;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Ray _ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(_ray,out _hit)){
                Debug.Log(_hit.transform.name);
                if(_hit.transform.tag!="bullet"){
                    bulletobj.transform.position=_hit.point;
                    Bomb(_hit.point);
                }
            }
        }
        fps.text="fps:"+(int)(1.0f/Time.unscaledDeltaTime);

    }

    void Bomb(Vector3 overlap_pos)
    {
        Collider[] fragments = Physics.OverlapSphere(overlap_pos, _radius);
        foreach (var fragment in fragments)
        {
            if(fragment.tag=="Building"){ 
                Rigidbody rb=fragment.GetComponent<Rigidbody>();
                Debug.Log("doing the right thing daughter");
                rb.useGravity=true;
                rb.isKinematic=false; 
                rb.AddExplosionForce(explosionpower,overlap_pos,_radius);
            }
        }
    }
}
