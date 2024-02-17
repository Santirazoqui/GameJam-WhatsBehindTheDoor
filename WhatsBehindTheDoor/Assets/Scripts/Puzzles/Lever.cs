using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] SpriteRenderer circleSprite;
    [SerializeField] LeverDoor leverDoor;

    [Header("Sprites")]
    [SerializeField] Sprite leverUp;
    [SerializeField] Sprite leverDown;
    
    private SpriteRenderer spriteRenderer;
    public bool isUp = true;

    private Color color_Red = new Color(0.9056604f, 0.252047f, 0.252047f);
    private Color color_Green = new Color(0.2980392f, 0.9137255f, 0.3647059f);

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = leverUp;
        circleSprite.color =  color_Red;
    }

    public void PullLever()
    {
        if(isUp)
        {
            spriteRenderer.sprite = leverDown;
            circleSprite.color = color_Green;
        } 
        else
        {
            spriteRenderer.sprite = leverUp;
            circleSprite.color = color_Red;
        }
        this.leverDoor.CheckLevers();
        isUp = !isUp;
    }

    public bool isLeverUp()
    {
        return isUp;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
