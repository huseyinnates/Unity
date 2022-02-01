using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecondMenu : MonoBehaviour
{
  public GameObject MainMenu,Setting;
  public Sprite img0,img1;
  public AudioSource ad;
  public void Resolution(int index){
      if(index==0){
         Debug.Log(Screen.currentResolution);
         Screen.SetResolution(1920,1080,true);
         Debug.Log(Screen.currentResolution); 
      }else if(index==1){
          Debug.Log(Screen.currentResolution);
          Screen.SetResolution(1240,720,true);
          Debug.Log(Screen.currentResolution);
      }
  }
   public void Sound(float a){
       ad.volume=a;
   }
   public void BloodEffect(bool t){
       
       if(t){
           Debug.Log("Blood effect Opened");
        MainMenu.GetComponent<Image>().sprite=img0;
        Setting.GetComponent<Image>().sprite=img0;
       }
       else{
           Debug.Log("Blood effect Closed");
           MainMenu.GetComponent<Image>().sprite=img1;
           Setting.GetComponent<Image>().sprite=img1;
       }   
   }
   public void Quality(int i){
       QualitySettings.SetQualityLevel(i);
   }
   public void BackToMenu(){
       MainMenu.SetActive(true);
       Setting.SetActive(false);
       ad.enabled=false;
   }
    public void BackToMenuFromNewScene(){
      SceneManager.LoadScene("UI");
   }
}
