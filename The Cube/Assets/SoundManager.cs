using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        PlayerMove,
        PlayerFloat,
        PlayerDuck,
    }
   public static void PlaySound (Sound sound)
    {
        GameObject soundObject = new GameObject("Sound");
        AudioSource auidoSource = soundObject.AddComponent<AudioSource>();
        auidoSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (RefGameAssets.SoundAudioClip soundAudioClip in RefGameAssets.assetInstance.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound" + sound + " not found!");
        return null;
    }

}
