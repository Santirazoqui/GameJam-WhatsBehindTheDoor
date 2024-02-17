using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool isLocked = true;
    [SerializeField] GameObject openDoorButton;

    [SerializeField] List<GameObject> propsToDestroy;

    [Header("Flip door")]
    [SerializeField] bool changeSpriteAfterFlip = false;
    [SerializeField] Sprite spriteAfterFlip;

    private GameManager gameManager;
    private AudioPlayer audioPlayer;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
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
            this.DestroyProps();
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
                if(this.changeSpriteAfterFlip && this.spriteAfterFlip != null)
                {
                    this.spriteRenderer.sprite = this.spriteAfterFlip;
                }
            }

            yield return new WaitForSeconds(0.005f);
        }
    }

    public void SetLocked(bool isLocked)
    {
        this.isLocked = isLocked;
    }

    private void DestroyProps()
    {
        if(propsToDestroy.Count == 0) { return; }
        foreach(GameObject prop in propsToDestroy)
        {
            prop.SetActive(false);
        }
    }
}
