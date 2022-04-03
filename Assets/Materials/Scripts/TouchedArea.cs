using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedArea : MonoBehaviour
{
    public GameObject effector,floor;
    public Material first,after;
    public Texture2D a,b;
    public Texture tex;
    public Shader shad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            floor.GetComponent<MeshRenderer>().material.SetTexture("_MainTex",tex);
            
            Debug.Log("Not working");
        }
        if(Input.GetMouseButton(1)){
           Color[] c=a.GetPixels(0);
           for(int i=0;i<c.Length;i++){
               c[i]=new Color(Random.Range(0,255),Random.Range(0,255),Random.Range(0,255),1);
           }
           a.SetPixels(c,0);
           a.Apply();
        }
    }
}
