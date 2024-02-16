using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool isLocked = true;
    [SerializeField] GameObject openDoorButton;
    private GameManager gameManager;
    private AudioPlayer audioPlayer;

    void Awake()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void OpenDoor()
    {
        if(isLocked)
        {
            this.audioPlayer.PlayLockedDoorClip();
        } 
        else
        {
            //Call Game manager to load new door (behind current one)
            this.gameManager.LoadNextDoor();
            this.audioPlayer.PlayOpenDoorClip();
            //flip the asset somehow and play opening door sound
            StartCoroutine(Rotate());
            this.openDoorButton.SetActive(false);
        }
    }

    IEnumerator Rotate()
    {
        int rotation = 0;
        while(rotation >= -180)
        {
            
            transform.Rotate(0, -1, 0);
            rotation--;
            
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite && rotation == -90)
            {
                sprite.sortingOrder = -sprite.sortingOrder;
            }

            yield return new WaitForSeconds(0.005f);
        }
    }

    public void SetLocked(bool isLocked)
    {
        this.isLocked = isLocked;
    }
}
