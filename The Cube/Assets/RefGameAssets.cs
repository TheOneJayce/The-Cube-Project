using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RefGameAssets : MonoBehaviour
{
    private static RefGameAssets _assetInstance;

    public static RefGameAssets assetInstance
    {
        get {
            if (_assetInstance == null) _assetInstance = Instantiate(Resources.Load<RefGameAssets>("Asset"));
            return _assetInstance;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
