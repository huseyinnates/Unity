using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Spawn : MonoBehaviour
{
   public GameObject player;

  void Awake(){

      PhotonNetwork.Instantiate(player.name,transform.position,Quaternion.identity);
  }

}
