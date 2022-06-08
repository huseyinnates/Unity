using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTest : MonoBehaviour
{ 

    public LineRenderer lines;
    public Transform TransformParent;
    public List<Transform> points=new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
       for(int i=0;i<TransformParent.childCount;i++){
           points.Add(TransformParent.GetChild(i).transform);
       }
       lines.positionCount=points.Count;
       Debug.Log(points.Count);
       for(int i=0;i<points.Count;i++){
        
          lines.SetPosition(i,points[i].position);
       }
    }
    int _Counts=0;
    bool draw_again=false;
    // Update is called once per frame
    void Update()
    { 
        if(points.Count!=_Counts){
            points=new List<Transform>();
            for(int i=0;i<TransformParent.childCount;i++){
             points.Add(TransformParent.GetChild(i).transform);
            }
            draw_again=true;
        }
        if(draw_again==true || SayIamChanged.MyPositionChanged==true){
            lines.positionCount=points.Count;
            Debug.Log(points.Count);
             for(int i=0;i<points.Count;i++)
            { 
            lines.SetPosition(i,points[i].position);
            draw_again=false;
            SayIamChanged.MyPositionChanged=false;
                 }
        

        }
            
        
    }
}
