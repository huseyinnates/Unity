using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileSystemSaveLoad
{
    static string path=Application.persistentDataPath+"LocationInfo.xz";

    public static void  SaveData(Data data){
        FileStream filestream;
        BinaryFormatter binaryformat=new BinaryFormatter();
        filestream=new FileStream(path,FileMode.Create);
        binaryformat.Serialize(filestream,data);
        filestream.Close();
    }
    public static Data LoadData(){
        if(File.Exists(path)){
            BinaryFormatter binaryformat=new BinaryFormatter();
            FileStream filestream=new FileStream(path,FileMode.Open);
            Data data =binaryformat.Deserialize(filestream) as Data;
            filestream.Close();
            return data;
        }else{
            Debug.Log("File not found in given direction");
            return null;
        }
    }

}
