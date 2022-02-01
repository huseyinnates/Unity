using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour, IDragHandler
{   
    Vector3 Startpoint;
    public AudioSource ads;
    void Start(){
        Startpoint=transform.position;
    }
    public RectTransform rectM,rectS;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position=eventData.position;
        float x=transform.position.x;
        float y=transform.position.y;
        if(x>1350 && x<1390 && y>540 && y<580){
             Debug.Log("x"+x+"y"+y); 
             transform.position=Startpoint;
            if(transform.name=="Play"){
                SceneManager.LoadScene("Sample");
            }
            if(transform.name=="Setting"){
                rectM.gameObject.SetActive(false);
                rectS.gameObject.SetActive(true);
                ads.enabled=true;
            }
            if(transform.name=="Exit"){
                Application.Quit();
            }
           
        }
    }


}
