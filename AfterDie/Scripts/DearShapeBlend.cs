using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DearShapeBlend : MonoBehaviour
{
    // Start is called before the first frame update
    public SkinnedMeshRenderer smr;
    public GameObject dearbones,DestroyDear,lightning;
    public Animator animator;
    float shapeweight=10f,timestart=0;
    int a=3;
    public float animationtime=10f;
    bool flag=false;
    public bool deadinfo=false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Armature_001|Armature_001Action")){
             if(a==3){
                timestart=Time.time;
                a=4;
             }
            
            if(Time.time-timestart>animationtime){
                flag=true;
            DestroyDear.SetActive(false);
             dearbones.SetActive(true);
             Destroy(lightning);
             deadinfo=true;
            
            }
             
        }
        if(flag==true){
             smr.SetBlendShapeWeight(0,shapeweight);
             Debug.Log("Pressed");
             if(shapeweight<95){
                   shapeweight+=10*Time.deltaTime;
             }
        }
    }
}
