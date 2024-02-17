using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    [SerializeField] Door door;

    [SerializeField] Lever lever1;
    [SerializeField] Lever lever2;
    [SerializeField] Lever lever3;

    public void CheckLevers()
    {
        bool lever1Down = lever1.isLeverUp();
        bool lever2Down = lever2.isLeverUp();
        bool lever3Down = lever3.isLeverUp();

        if(lever1Down && lever2Down && lever3Down)
        {
            //play unlock sound?
            door.SetLocked(false);
        }
    }
}
