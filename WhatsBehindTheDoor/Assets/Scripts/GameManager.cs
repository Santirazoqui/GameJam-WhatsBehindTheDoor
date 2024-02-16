using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> doorsToUse;
    [SerializeField] List<GameObject> firstDoorsToUse;

    private readonly Vector3 doorSpawnPosition = new Vector3(-1.5f, 1.31f, 0);
    private int currentDoor = 0;

    public void LoadNextDoor()
    {
        currentDoor++;
        if(currentDoor < firstDoorsToUse.Count)
        {
            Instantiate(firstDoorsToUse[currentDoor], 
                    doorSpawnPosition,
                    Quaternion.identity
                    );
        } 
        else
        {
            //Load random door form the other ones
        }

    }

    public void Start()
    {
        Instantiate(firstDoorsToUse[0], 
                    doorSpawnPosition,
                    Quaternion.identity
                    );

    }
}
