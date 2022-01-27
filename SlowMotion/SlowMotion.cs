using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public void SceneSpeed(float sf){
        Time.timeScale=sf;
        Time.fixedDeltaTime=Time.timeScale*0.02f;
    }
}
