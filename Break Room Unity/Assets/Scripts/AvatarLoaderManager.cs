using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe;

public class AvatarLoaderManager : MonoBehaviour
{
    [SerializeField]
    private string avatarURL = "https://d1a370nemizbjq.cloudfront.net/209a1bc2-efed-46c5-9dfd-edc8a1d9cbe4.glb";

    private void Start()
    {
        Debug.Log($"Started loading avatar");
        AvatarLoader avatarLoader = new AvatarLoader();
        avatarLoader.OnCompleted += AvatarLoadComplete;
        avatarLoader.OnFailed += AvatarLoadFail;
        avatarLoader.LoadAvatar(avatarURL);
    }

    private void AvatarLoadComplete(object sender, CompletionEventArgs args)
    {
        Debug.Log($"Avatar loaded");
    }

    private void AvatarLoadFail(object sender, FailureEventArgs args)
    {
        Debug.Log($"Avatar loading failed with error message: {args.Message}");
    }
    
}
