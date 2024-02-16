using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] [Range(0f, 1f)] float volume;
    [SerializeField] DoorLock doorLock;

    private AudioPlayer audioPlayer;

    void Awake()
    {
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void PickUpKey()
    {
        doorLock.SetUnlockable(true);
        PlayClip();
        Destroy(gameObject);
    }

    private void PlayClip()
    {
        if(this.audioPlayer)
        {
            this.audioPlayer.PlayClip(clip, volume);
        }
    }
}
