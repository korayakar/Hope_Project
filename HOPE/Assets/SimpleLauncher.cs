using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SimpleLauncher : MonoBehaviourPunCallbacks
{
	
	public PhotonView playerPrefab;
	
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

	public override void OnConnectedToMaster(){
		Debug.Log("Connected to Master");
		PhotonNetwork.JoinRandomOrCreateRoom();
	}
	
	public override void OnJoinedRoom(){
		Debug.Log("Joined a room.");
		PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
	}
	
}