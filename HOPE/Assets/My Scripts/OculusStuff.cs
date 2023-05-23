using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using System;
using Oculus.Avatar2;
//using Photon.Pun;
//using Photon.Realtime;
using CAPI = Oculus.Avatar2.CAPI;
using UnityEditor;

public class OculusStuff : MonoBehaviour
{/*
    public UInt64 _userId = 0;
    public string appID;
    public string sampleAvatar = "sampleAvatar";
    //public StreamingAvatar _streamingAvatar;

    public GameObject playerGo, playerPrefab;
    public Transform StartRigGo;
    public int playerNum;
    public Transform[] playerSpwnPnts = new Transform[2];
    public bool ServerBool;

    private void Awake()
    {

        try
        {
            Core.AsyncInitialize();
            Entitlements.IsUserEntitledToApplication().OnComplete(EntitlementCallback);
        }
        catch (UnityException e)
        {
            Debug.LogError("Platform failed to initialize due to exception.");
            Debug.LogException(e);
            // Immediately quit the application.
            UnityEngine.Application.Quit();
        }

    }

    void EntitlementCallback(Message msg)
    {
        if (msg.IsError) // User failed entitlement check
        {
            UnityEngine.Application.Quit();
        }
        else // User passed entitlement check
        {
            // Log the succeeded entitlement check for debugging.
            Debug.Log("Game On!");
            StartCoroutine(StartOvrPlatform());
        }

    }
    IEnumerator StartOvrPlatform()
    {
        // Ensure OvrPlatform is Initialized
        if (OvrPlatformInit.status == OvrPlatformInitStatus.NotStarted)
        {
            OvrPlatformInit.InitializeOvrPlatform();
        }

        while (OvrPlatformInit.status != OvrPlatformInitStatus.Succeeded)
        {
            if (OvrPlatformInit.status == OvrPlatformInitStatus.Failed)
            {
                OvrAvatarLog.LogError($"Error initializing OvrPlatform. Falling back to local avatar", sampleAvatar);
                //LoadLocalAvatar();
                yield break;
            }

            yield return null;
        }

        // user ID == 0 means we want to load logged in user avatar from CDN
        if (_userId == 0)
        {
            // Get User ID
            bool getUserIdComplete = false;
            Users.GetLoggedInUser().OnComplete(message =>
            {
                if (message.IsError)
                {
                    var e = message.GetError();
                    OvrAvatarLog.LogError($"Error loading CDN avatar: {e.Message}. Falling back to local avatar", sampleAvatar);
                }
                else
                {
                    _userId = message.Data.ID;
                    //build multiplayer login room

                    ConnectToServer();
                    //_streamingAvatar.gameObject.SetActive(true);
                    // _streamingAvatar.StartAvatar(this);
                }


            });


        }
    }
    public void ConnectToServer()
    {
        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 20;
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions
        {
            MaxPlayers = 2,
            IsVisible = true,
            IsOpen = true,
        };

        PhotonNetwork.JoinOrCreateRoom("GameRoom", roomOptions, TypedLobby.Default);

    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        ServerBool = true;
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        //PhotonNetwork.CurrentRoom.PlayerCount;

        playerNum = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        //only 10 players in room options
        if (playerNum <= playerSpwnPnts.Length)
        {
            StartRigGo.transform.SetPositionAndRotation(playerSpwnPnts[playerNum].transform.position,
                    playerSpwnPnts[playerNum].transform.rotation);
        }
        else
        {
            StartRigGo.transform.SetPositionAndRotation(playerSpwnPnts[0].transform.position,
                    playerSpwnPnts[0].transform.rotation);
        }

        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        object[] userID0 = new object[1] { Convert.ToInt64(_userId) };
        playerGo = PhotonNetwork.Instantiate(playerPrefab.name, StartRigGo.position, StartRigGo.rotation, 0, userID0);
        StartRigGo.gameObject.SetActive(false);
    }
    */
}