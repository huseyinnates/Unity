using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRigidbody : MonoBehaviour
{
    float passtime=4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PassTheKinematic");
    }

   IEnumerator PassTheKinematic(){
       yield return new WaitForSeconds(passtime);
       GetComponent<Rigidbody>().isKinematic=true;
       GetComponent<Rigidbody>().useGravity=false;
   }
}
