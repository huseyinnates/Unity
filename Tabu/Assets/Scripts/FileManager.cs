using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FileManager : MonoBehaviour
{


    public void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Data data = new Data();

            FileSaveLoad.SaveData(data);

        }
        if (Input.GetKey(KeyCode.B))
        {
            Data da = FileSaveLoad.LoadData();
            for (int i = 0; i < 5; i++)
            {
                Debug.Log(da.data[i]);
            }
        }
    }

}