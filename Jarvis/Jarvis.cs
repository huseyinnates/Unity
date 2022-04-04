using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Jarvis 
{
	public int index;
	public List<Vector3> hull = new List<Vector3>();
	public int orientation(Vector3 p,Vector3 q,Vector3 r)
	{
		float val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);
	
		if (val == 0){
            return 0;
        }else{
            return (val > 0) ? 1: 2;
        } 
		
	}
    public void convexHull(Vector3[] points, int n){
        
		

            
		int l = 0;
		for (int i = 1; i < n; i++){
            if (points[i].x < points[l].x){
                l = i;
            }		
        }
			
	
		int p = l, q;
		do
		{
			hull.Add(points[p]);
			index++;
	
			q = (p + 1) % n;
			
			for (int i = 0; i < n; i++)
			{
			
			if (orientation(points[p], points[i], points[q])== 2){
				q = i;
			}
				
			}
	
			p = q;
	
		} while (p != l); 



		
	}
    
}
