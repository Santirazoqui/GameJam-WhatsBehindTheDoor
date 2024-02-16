using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] Door door;

    [Header("Audio Clips")]
    [SerializeField] AudioClip lockedClip;
    [SerializeField] [Range(0f, 1f)] float lockedVolume = 0.2f;
    [SerializeField] AudioClip openedClip;
    [SerializeField] [Range(0f, 1f)] float openedVolume = 0.2f;
    
    [Header("Lock")]
    [SerializeField] Sprite openedLock;
    private bool isUnlockable = false;

    private AudioPlayer audioPlayer;

    void Awake()
    {
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void OpenLock()
    {
        if(this.isUnlockable == false)
        {
            this.audioPlayer.PlayClip(lockedClip, lockedVolume);
        }
        else
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = this.openedLock;
            Rigidbody2D openedLockRigidBody = gameObject.AddComponent<Rigidbody2D>();
            this.audioPlayer.PlayClip(openedClip, openedVolume);
            this.door.SetLocked(false);
        }
    }

    public void SetUnlockable(bool canBeUnlocked)
    {
        this.isUnlockable = canBeUnlocked;
    }
}
