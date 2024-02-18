using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCodeDoor : MonoBehaviour
{
    [SerializeField] SpriteRenderer wallLeft;
    [SerializeField] SpriteRenderer wallRight;
    [SerializeField] Sprite wallCodeLeft;
    [SerializeField] Sprite wallCodeRight;

    void Awake()
    {
        this.wallLeft.sprite = wallCodeLeft;
        this.wallRight.sprite = wallCodeRight;
    }
}
