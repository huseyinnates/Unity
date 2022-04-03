using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
using System;


public class MenuControllers : MonoBehaviour
{
    public TextMeshProUGUI scoreboard;
    public Button _start,_settings,_exit,_back,_tabu,_next;
    public TextMeshProUGUI[] txt=new TextMeshProUGUI[5];
    public Button[] btn=new Button[5];
    public bool btnbool=false;
    public bool stb=true,seb=true,exb=true,bab=false,tab=false,neb=false;
    public string[] keywords=new string[5];
    int Index,Score=0;
    List<string> data;
    // Start is called before the first frame update
    void Start()
    {
        ReadData();
        Index=ReadLastDataIndex();
        Debug.Log("Index:"+Index);
        
    }

    public void StartGame(){
        Debug.Log("Starting...");
        ReverseActivation();
        SetWords(); 
    }
    public void SettingsGame(){
        Debug.Log("Settings...");
    }
    public void ExitGame(){
        Debug.Log("Exit...");
        Index+=1;
        WriteLastDataIndex(Index);
    }
    public void BackGame(){
        Debug.Log("Back...");
        ReverseActivation();
    
    }
    public void Tabu(){
        Score-=1;
        Index+=1;
        scoreboard.text=Index.ToString();
        SetWords();
    }
    public void Next(){
        Score+=1;
        Index+=1;
        scoreboard.text="Score:"+Index.ToString();
        SetWords();
    }
    void ReverseActivation(){
        stb=!stb;
        seb=!seb;
        exb=!exb;
        bab=!bab;
        tab=!tab;
        neb=!neb;
        btnbool=!btnbool;
      for (int i = 0; i < 5; i++)
      {
            btn[i].gameObject.SetActive(btnbool);   
      }
        _start.gameObject.SetActive(stb);
        _settings.gameObject.SetActive(seb);
        _exit.gameObject.SetActive(exb);
        _back.gameObject.SetActive(bab);
        _tabu.gameObject.SetActive(tab);
        _next.gameObject.SetActive(neb);
       
    }
    void ReadData(){
        string path="C:/Users/matth/Desktop/data.txt"; //Application.streamingAssetsPath+"/data.txt";
        data=File.ReadAllLines(path).ToList();
        foreach(string str in data){
            Debug.Log(str);
        }
       
    }
    void SetWords(){
        ReadDataByIndex();
        for(int i=0;i<5;i++){
            txt[i].text=keywords[i];
        }
    }
    void ReadDataByIndex(){
        for(int i=0;i<5;i++){
            keywords[i]=data[Index*5+i];
        }
    }
    int ReadLastDataIndex(){
        string path="C:/Users/matth/Desktop/lastdataindex.txt"; 
        List<string> data=File.ReadAllLines(path).ToList();
        int ret=0;
        foreach(string str in data){
            ret=int.Parse(str);
            Debug.Log(ret);
        }
        return ret;
    }
    void WriteLastDataIndex(int _index){
        string path="C:/Users/matth/Desktop/lastdataindex.txt"; 
        File.WriteAllText(path,_index.ToString()); 
        Index=_index; 
        Debug.Log(Index);
    }
    void SelectRandom(){
     
    }
    void DisplayData(){
    
    }

   
 
}
