using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> doorsToUse;
    [SerializeField] List<GameObject> firstDoorsToUse;
    [SerializeField] bool debugging = false;

    private readonly Vector3 doorSpawnPosition = new Vector3(-1.5f, 1.31f, 0);
    private int currentDoor = 0;

    public void LoadNextDoor()
    {
        if(debugging){ return; }

        currentDoor++;
        if(currentDoor < firstDoorsToUse.Count)
        {
            Instantiate(firstDoorsToUse[currentDoor], 
                    doorSpawnPosition,
                    Quaternion.identity
                    );
        } 
        else if (doorsToUse.Count > 0)
        {
            int index = Random.Range(0, doorsToUse.Count - 1);
            //En este caso la pos del Instantiate es porque quedo algo mal con las puertas. Las que estan abajo de un empry object spawnean mal 
            //por que el empty object es el que va a la pos. Voy a meter todas las nuevas abajo de un empty object y dejar las primeras quietas por tiempo

            Instantiate(doorsToUse[index], 
                    new Vector3(0, 0, 0),
                    Quaternion.identity
                    );
            doorsToUse.RemoveAt(index);
            //Load random door form the other ones
        }
        else
        {
            Debug.Log("Finish!");
        }

    }

    public void Start()
    {
        if(!debugging)
        {
            Instantiate(firstDoorsToUse[0], 
                        doorSpawnPosition,
                        Quaternion.identity
                        );
        }
    }
}
