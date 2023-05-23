using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar2;
//using Photon.Pun;
using System;

public class StreamingAvatar : OvrAvatarEntity
{/*
    public OculusStuff networkCon;
    PhotonView view;
    public bool startBool;
    public GameObject mainCam;
    WaitForSeconds waitTime = new WaitForSeconds(.08f);
    public byte[] avatarBytes;

    protected override void Awake()
    {
        StartLoadingAvatar();
        base.Awake();   
    }

    public void StartLoadingAvatar()
    {
        //get used id 
        PhotonView parentView = GetComponentInParent<PhotonView>();
        object[] args = parentView.InstantiationData;
        Int64 avatarID = (Int64)args[0];
        _userId = Convert.ToUInt64(avatarID);

        // avatar view for streaming
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            SetIsLocal(true);
            _creationInfo.features = Oculus.Avatar2.CAPI.ovrAvatar2EntityFeatures.Preset_Default;
        }
        else
        {
            SetIsLocal(false);
            _creationInfo.features = Oculus.Avatar2.CAPI.ovrAvatar2EntityFeatures.Preset_Remote;
            mainCam.SetActive(false);
        }

        SetBodyTracking(FindObjectOfType<SampleInputManager>());
        SetLipSync(FindObjectOfType<OvrAvatarLipSyncContext>());
        StartCoroutine(LoadAvatarWithId());
    }

    IEnumerator LoadAvatarWithId()
    {
        var hasAvatarRequest = OvrAvatarManager.Instance.UserHasAvatarAsync(_userId);
        while (!hasAvatarRequest.IsCompleted) { yield return null; }
        LoadUser();
    }

    public void AvatarCreated()
    {
        if (view.IsMine)
        {
            StartCoroutine(StreamAvatarData());
        }
    }

    IEnumerator StreamAvatarData()
    {
        avatarBytes = RecordStreamData(activeStreamLod);
        view.RPC(nameof(RPC_PlayAvatarData), RpcTarget.Others, avatarBytes);
        yield return waitTime;
        StartCoroutine(StreamAvatarData());
    }

    [PunRPC]
    public void RPC_PlayAvatarData(byte[] aBytes)
    {
        avatarBytes = aBytes;
        ApplyStreamData(avatarBytes);
    }
    */
}
