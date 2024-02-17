using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField] Door elevatorDoor;

    [Header("UI")]
    [SerializeField] GameObject elevatorButtonUp;
    [SerializeField] GameObject elevatorButtonDown;

    [Header("Switch")]
    [SerializeField] Sprite elevatorSwitch;
    [SerializeField] Sprite elevatorSwitchUp;
    [SerializeField] Sprite elevatorSwitchDown;
    private SpriteRenderer spriteRenderer;

    [Header("Audio")]
    [SerializeField] AudioClip elevatorMusic;
    [SerializeField] AudioClip elevatorArrivedClip;
    [SerializeField] float audioClipLengthWaitime;
    private AudioSource mainAudioSource;
    private AudioPlayer mainAudioPlayer;
    private AudioSource elevatorAudioPlayer;

    void Awake()
    {
        this.mainAudioPlayer = FindObjectOfType<AudioPlayer>();
        this.elevatorAudioPlayer = GetComponent<AudioSource>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.mainAudioSource = this.mainAudioPlayer.GetComponent<AudioSource>();
    }

    public void CallElevator(bool up)
    {
        if(up)
        {
            this.spriteRenderer.sprite = this.elevatorSwitchUp;
        }
        else
        {
            this.spriteRenderer.sprite = this.elevatorSwitchDown;
        }

        this.elevatorButtonUp.SetActive(false);
        this.elevatorButtonDown.SetActive(false);

        StartCoroutine(ElevatorMoving());
    }

    IEnumerator ElevatorMoving()
    {
        this.mainAudioSource.Pause();
        this.elevatorAudioPlayer.Play();

        yield return new WaitForSeconds(audioClipLengthWaitime);

        this.mainAudioPlayer.PlayClip(this.elevatorArrivedClip, 1f);

        this.elevatorAudioPlayer.Stop(); 
        this.spriteRenderer.sprite = this.elevatorSwitch;
        this.mainAudioSource.UnPause();
        this.elevatorDoor.SetLocked(false);
    }
}
