using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Open Door")]
    [SerializeField] AudioClip openDoorClip;
    [SerializeField] [Range(0f, 1f)] float openDoorVolume;

    [Header("Locked Door")]
    [SerializeField] AudioClip lockedDoorClip;
    [SerializeField] [Range(0f, 1f)] float lockedDoorVolume;

    public void PlayOpenDoorClip()
    {
        if(openDoorClip != null)
        {
            PlayClip(openDoorClip, openDoorVolume);
        }
    }

    public void PlayLockedDoorClip()
    {
        if(lockedDoorClip != null)
        {
            PlayClip(lockedDoorClip, lockedDoorVolume);
        }
    }


    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
