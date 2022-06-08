using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class MeshShaper : MonoBehaviour
{
    public MeshFilter _meshfilter,secondfilter;
    public Transform target;
    public float  radius=10f,high=1f;
    Vector3[] vertices;
    int[] triangles;
    Mesh drawmesh;
    MeshFilter objectfilter;
    float vertexcount;
    void Start(){
        drawmesh=new Mesh();
        int trisize=_meshfilter.mesh.triangles.Length;
        vertices=new Vector3[_meshfilter.mesh.vertexCount];
        triangles=new int[trisize];
        for(int i=0;i<trisize;i++){
            triangles[i]=_meshfilter.mesh.triangles[i];
        }
        Matrix4x4 localToWorld = transform.localToWorldMatrix;
        vertexcount=_meshfilter.mesh.vertices.Length;
        for(int i = 0; i<_meshfilter.mesh.vertices.Length; ++i){
        Vector3 world_v = localToWorld.MultiplyPoint3x4(_meshfilter.mesh.vertices[i]);
        //Mathf.PingPong(Time.time,world_v.z);//Mathf.Sin(world_v.x*Time.time+world_v.z);    // Mathf.PerlinNoise(world_v.x,world_v.z*Time.time)*3;
        vertices[i]=world_v;
        Debug.Log(world_v);
     }
     drawmesh.SetVertices(vertices);
     drawmesh.triangles=triangles;
     drawmesh.RecalculateNormals();
     drawmesh.RecalculateBounds();
     secondfilter.mesh=drawmesh;
     secondfilter.gameObject.GetComponent<MeshCollider>().sharedMesh=drawmesh;
       

    }
    void Update(){
        if(Input.GetMouseButton(0)){
            DrawAgain(target.position);
        }if(Input.GetMouseButton(1)){
            ReverseDrawAgain(target.position);
        }
    }

    void DrawAgain(Vector3 target){
        for(int i = 0; i<vertexcount; ++i){
        if(Vector3.Distance(target,vertices[i])<radius){
            vertices[i].y-=high*Time.deltaTime;
        }
   //Mathf.PingPong(Time.time,world_v.z);//Mathf.Sin(world_v.x*Time.time+world_v.z);    // Mathf.PerlinNoise(world_v.x,world_v.z*Time.time)*3;
      
     }
     drawmesh.SetVertices(vertices);
     drawmesh.triangles=triangles;
     drawmesh.RecalculateNormals();
     drawmesh.RecalculateBounds();
     secondfilter.mesh=drawmesh;
     secondfilter.gameObject.GetComponent<MeshCollider>().sharedMesh=drawmesh;
    }
     void ReverseDrawAgain(Vector3 target){
        for(int i = 0; i<vertexcount; ++i){
        if(Vector3.Distance(target,vertices[i])<radius){
            vertices[i].y+=high*Time.deltaTime; 
        }
   //Mathf.PingPong(Time.time,world_v.z);//Mathf.Sin(world_v.x*Time.time+world_v.z);    // Mathf.PerlinNoise(world_v.x,world_v.z*Time.time)*3;
      
     }
     drawmesh.SetVertices(vertices);
     drawmesh.triangles=triangles;
     drawmesh.RecalculateNormals();
     drawmesh.RecalculateBounds();
     secondfilter.mesh=drawmesh;
     secondfilter.gameObject.GetComponent<MeshCollider>().sharedMesh=drawmesh;
    }
}