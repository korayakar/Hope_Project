using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Leave : MonoBehaviour
{
  public void Leave_Room()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);

    }
}
