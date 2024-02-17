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
        bool lever1Up = lever1.isLeverUp();
        bool lever2Up = lever2.isLeverUp();
        bool lever3Up = lever3.isLeverUp();

        if(!lever1Up && !lever2Up && !lever3Up)
        {
            //play unlock sound?
            door.SetLocked(false);
        }
    }
}
