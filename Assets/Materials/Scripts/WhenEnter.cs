// A grenade
// - instantiates an explosion Prefab when hitting a surface
// - then destroys itself

using UnityEngine;
using System.Collections;

public class WhenEnter : MonoBehaviour
{
    

    void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }
}
