using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool isLocked = true;

    public void OpenDoor()
    {
        if(this.isLocked)
        {
 
        } 
        else
        {
            //Call Game manager to load new door (behind current one)
            //flip the asset somehow and play opening door sound
            StartCoroutine(Rotate());
        }
    }

    IEnumerator Rotate()
    {
        int rotation = 0;
        while(rotation >= -180)
        {
            transform.Rotate(0, -1, 0);
            rotation--;
            yield return new WaitForSeconds(0.005f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
