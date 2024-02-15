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
            Debug.Log("start rotating");
            StartCoroutine(Rotate());

            /*
            int rotation = 0;
            int count = 0;
            while(rotation >= -180 || count < 1000)
            {
                //this freezes unity (the whole f*ing program not just the game)
                /*
                Quaternion target = Quaternion.Euler(0, -180, 0);

                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
                count++;
                
                
                
                transform.rotation = Quaternion.Euler(0, rotation, 0);
                Debug.Log(rotation);
                rotation--;
            }*/
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
