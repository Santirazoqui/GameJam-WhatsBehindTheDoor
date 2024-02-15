using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> doorsToUse;
    [SerializeField] GameObject startDoor;
    private readonly Vector3 doorSpawnPosition = new Vector3(-1.5f, 1.31f, 0);

    public void LoadNextDoor()
    {

    }

    public void Start()
    {
        Instantiate(startDoor, 
                    doorSpawnPosition,
                    Quaternion.identity
                    );

    }
}
