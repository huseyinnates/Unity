using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTest : MonoBehaviour
{
    public List<GameObject> cubes;
    int index=0;
   // Stack mystack=new Stack(); 
    Queue queue=new Queue();
    public Transform startpos;
    void Start(){
        Transform[] childarr=transform.GetComponentsInChildren<Transform>();
        foreach(Transform child in childarr){
//            Debug.Log(child.name);
            cubes.Add(child.gameObject);
        }
        cubes.RemoveAt(0);
    }
    void Update()
    {
    //    if(index<cubes.Count && Input.GetMouseButtonDown(0)){
    //        mystack.Push(cubes[index]);
    //        GameObject peek= (GameObject)mystack.Peek();
    //        peek.transform.position=startpos.position+new Vector3(0,1*index,0);
    //        index++;
    //        Debug.Log("index:"+index);
    //    }
    //    if(index>0 && index<cubes.Count+1 && Input.GetMouseButtonDown(1)){
    //        index--;
    //        GameObject pop=(GameObject)mystack.Pop();
    //        pop.transform.position=startpos.position+new Vector3(2,1*((cubes.Count-1)-index),0);
    //        Debug.Log("index:"+index);
    //    }

    if(index<cubes.Count && Input.GetMouseButtonDown(0)){
           //mystack.Push(cubes[index]);
            queue.Enqueue(cubes[index]);
            Queue queue2=new Queue(queue);
            int maxcount=queue2.Count;
            while(queue2.Count>0){
               GameObject obj=(GameObject)queue2.Dequeue();
               obj.transform.position=startpos.position+new Vector3(0,(queue2.Count),0);
            }
           index++;
           Debug.Log("index:"+index);
       }
       if(index>0 && index<cubes.Count+1 && Input.GetMouseButtonDown(1)){
           index--;
           GameObject pop=(GameObject)queue.Dequeue();
           pop.transform.position=startpos.position+new Vector3(2,1*((cubes.Count-1)-index),0);
           Debug.Log("index:"+index);
       }
    }
}
