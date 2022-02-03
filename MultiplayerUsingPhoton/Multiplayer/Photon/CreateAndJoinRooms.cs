using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public GameObject create,join;
    // Start is called before the first frame update
    public void CreateRoom(){
        PhotonNetwork.CreateRoom(create.GetComponent<TMP_InputField>().text);
        Debug.Log("Room Created"+create.GetComponent<TMP_InputField>().text);
    }
    public void JoinRoom(){
        PhotonNetwork.JoinRoom(join.GetComponent<TMP_InputField>().text);
        Debug.Log("Joined to Room"+join.GetComponent<TMP_InputField>().text);
    }
    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("Multiplayer");
    }
}
