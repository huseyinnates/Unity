using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentPlane : MonoBehaviour
{
    bool gate=true;
    public GameObject create,sphr;
    List<Vector3> cutpoints=new List<Vector3>();
    List<Vector3> getverts=new List<Vector3>();
    Mesh _mesh,mesh1,mesh2;
    public GameObject gm1,gm2;
    void Start(){
        _mesh=create.GetComponent<MeshFilter>().sharedMesh;
        _mesh.GetVertices(getverts);
        int i=0;
        foreach(Vector3 at in getverts){
            Debug.Log(at+" "+i++);
        }
    }
   public float offset=20f;
   Vector3 worldPosition;
   int lengthoflist=0;
    void Update()
    {       
       
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane+offset;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        
        if(Input.GetMouseButton(0)){
            SendRay();
        }
        if(Input.GetMouseButton(1)){
           // CutOperation();
            nGenPlane();
        }
       
        
    }
    void SendRay(){
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)){
        if(hit.transform.tag!="sp"){
            Instantiate(sphr,hit.point,Quaternion.identity);
            cutpoints.Add(hit.point);
            lengthoflist++;
          
        }
        }

    }
    void nGenPlane(){
        if(lengthoflist>=3){
            Vector3[] part1=new Vector3[lengthoflist];
            List<int> triangle1=new List<int>();
            cutpoints.CopyTo(part1);

            Jarvis jar=new Jarvis();
            jar.convexHull(part1,lengthoflist);
            Debug.Log("BBBBBBBB");
            Vector3[] rpart1=new Vector3[jar.index];
            jar.hull.CopyTo(rpart1);

            for(int i=0;i<jar.index-2;i++){
            triangle1.Add(i+2);
            triangle1.Add(i+1);
            triangle1.Add(0);
            Debug.Log("CCCCC");
            }

            mesh1=new Mesh();
            mesh1.SetVertices(rpart1);
            mesh1.triangles=triangle1.ToArray();
            mesh1.RecalculateNormals();
            gm1.GetComponent<MeshFilter>().sharedMesh=mesh1;
            
        
    }}



    void CutOperation(){
        Vector3[] part1=new Vector3[lengthoflist+2];
        Vector3[] part2=new Vector3[lengthoflist+2];


        cutpoints.CopyTo(part1);
        part1[lengthoflist]=getverts[3];
        part1[lengthoflist+1]=getverts[2];
        
        cutpoints.CopyTo(part2);
        part2[lengthoflist]=getverts[0];
        part2[lengthoflist+1]=getverts[1];
        
        for(int i=0;i<lengthoflist+2;i++){
            Debug.Log(i+":"+part1[i]);
        }

        List<int> triangle1=new List<int>();
        List<int> triangle2=new List<int>();
        for(int i=0;i<lengthoflist;i++){
            triangle1.Add(i+1);
            triangle1.Add(i);
            triangle1.Add(lengthoflist+1);
        }
        for(int i=0;i<lengthoflist;i++){
            triangle2.Add(i+1);
            triangle2.Add(lengthoflist+1);
            triangle2.Add(i);
        }
        mesh1=new Mesh();
        mesh1.SetVertices(part1);
        mesh1.triangles=triangle1.ToArray();
        mesh1.RecalculateNormals();
        gm1.GetComponent<MeshFilter>().sharedMesh=mesh1;
        

        mesh2=new Mesh();
        mesh2.SetVertices(part2);
        mesh2.triangles=triangle2.ToArray();
        mesh2.RecalculateNormals();
        gm2.GetComponent<MeshFilter>().sharedMesh=mesh2;
              
    }
}
   

