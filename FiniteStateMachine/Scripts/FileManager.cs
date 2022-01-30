using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FileManager : MonoBehaviour
{

    public GameObject locations,inst;

    public void Update(){
        
        if(Input.GetKey(KeyCode.A)){
             Data data=new Data();
            foreach (Component item in locations.GetComponentsInChildren<Component>())
        {
            Vector3 v3=item.GetComponent<Transform>().position;
            //Debug.Log(v3);
           
            data.vec3.Add(v3.x);
            data.vec3.Add(v3.y);
            data.vec3.Add(v3.z);
           
       
        }
         FileSystemSaveLoad.SaveData(data);
        
        }
          if(Input.GetKey(KeyCode.B)){
            Vector3 posi;
            Data da=FileSystemSaveLoad.LoadData();
            for(int i=0;i<da.vec3.Count;i+=3){
                 posi.x=da.vec3[i];
                 posi.y=da.vec3[i+1];
                 posi.z=da.vec3[i+2];
                // Debug.Log( "loaded data X:"+da.vec3[i]+"Y:"+da.vec3[i+1]+"Z:"+da.vec3[i+2]);
                 Instantiate(inst,posi,Quaternion.identity);
            }
          
        }
    }
        
}
