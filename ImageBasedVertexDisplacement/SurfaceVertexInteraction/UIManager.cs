using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject CanvasUI;
    public void NextChapter(){
        CanvasUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1%4);
    }
    public void GameExit(){
        Application.Quit();
    }
}
