using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Avatar2;
using System;

public class OculusStuff : MonoBehaviour
{
    public UInt64 _userId = 0;
    public string sampleAvatar = "sampleAvatar";
    public StreamingAvatar _streamingAvatar;
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
    //,
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
                if (!message.IsError)
                {
                    _userId = message.Data.ID;

                    //build multiplayer login room
                    _streamingAvatar.gameObject.SetActive(true);
                    _streamingAvatar.playerCon = this;
                    _streamingAvatar.StartAvatar(this);
                }
                else
                {
                    var e = message.GetError();
                    OvrAvatarLog.LogError($"Error loading CDN avatar: {e.Message}. Falling back to local avatar", sampleAvatar);
                }

            });
        }

    }


}
