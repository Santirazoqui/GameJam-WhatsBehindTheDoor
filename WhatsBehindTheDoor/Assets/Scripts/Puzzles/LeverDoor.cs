using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    [SerializeField] Door door;

    [SerializeField] Lever lever1;
    [SerializeField] Lever lever2;
    [SerializeField] Lever lever3;

    [SerializeField] AudioClip doorUnlockClip;

    [SerializeField] bool checkLevers = true;

    private AudioPlayer audioPlayer;

    void Awake()
    {
        this.audioPlayer = FindObjectOfType<AudioPlayer>();

        if(!checkLevers)
        {
            StartCoroutine(DelayUnlock());
        }
    }

    IEnumerator DelayUnlock()
    {
        yield return new WaitForSeconds(2);
        this.audioPlayer.PlayClip(doorUnlockClip, 0.8f);
    }

    public void CheckLevers()
    {
        if(!checkLevers) { return; }

        bool lever1Up = lever1.isLeverUp();
        bool lever2Up = lever2.isLeverUp();
        bool lever3Up = lever3.isLeverUp();

        if(!lever1Up && !lever2Up && !lever3Up)
        {
            this.audioPlayer.PlayClip(this.doorUnlockClip, 0.2f);
            door.SetLocked(false);
        }
    }
}
