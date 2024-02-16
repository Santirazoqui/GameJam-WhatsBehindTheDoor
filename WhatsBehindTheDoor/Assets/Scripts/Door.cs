using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool isLocked = true;
    [SerializeField] GameObject openDoorButton;
    private GameManager gameManager; 

    void Awake()
    {
        this.gameManager = FindObjectOfType<GameManager>();
    }

    public void OpenDoor()
    {
        if(this.isLocked)
        {
 
        } 
        else
        {
            //Call Game manager to load new door (behind current one)
            this.gameManager.LoadNextDoor();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
