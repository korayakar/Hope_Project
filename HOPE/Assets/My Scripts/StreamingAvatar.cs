using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar2;

public class StreamingAvatar : OvrAvatarEntity
{
    public OculusStuff playerCon;

    // Start is called before the first frame update
    public void StartAvatar(OculusStuff playercon)
    {
        playerCon = playercon;
        _userId = playerCon._userId;
        StartCoroutine(LoadAvatarWithId());

    }

    IEnumerator LoadAvatarWithId()
    {
        var hasAvatarRequest = OvrAvatarManager.Instance.UserHasAvatarAsync(_userId);
        while (!hasAvatarRequest.IsCompleted) { yield return null; }
        LoadUser();
    }
}
