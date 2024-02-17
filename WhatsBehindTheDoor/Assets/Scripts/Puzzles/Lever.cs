using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] SpriteRenderer circleSprite;
    [SerializeField] LeverDoor leverDoor;
    [SerializeField] AudioClip pullClip;
    public bool isUp = true;

    [Header("Levers")]
    [SerializeField] bool shiftLeverA = false;
    [SerializeField] Lever other_lever_a;
    [SerializeField] bool shiftLeverB = false;
    [SerializeField] Lever other_lever_b;

    [Header("Sprites")]
    [SerializeField] Sprite leverUp;
    [SerializeField] Sprite leverDown;
    
    private SpriteRenderer spriteRenderer;
    private AudioPlayer audioPlayer;

    private Color color_Red = new Color(0.9056604f, 0.252047f, 0.252047f);
    private Color color_Green = new Color(0.2980392f, 0.9137255f, 0.3647059f);

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
        if(isUp)
        {
            spriteRenderer.sprite = leverUp;
            circleSprite.color = color_Red;
        } 
        else
        {
            spriteRenderer.sprite = leverDown;
            circleSprite.color = color_Green;
        } 
    }

    public void PullLever()
    {
        ChangeSpriteAndCircle();
        ShiftLevers();
        this.audioPlayer.PlayClip(pullClip, 0.1f);
        isUp = !isUp;
        this.leverDoor.CheckLevers();
    }

    public void ChangeSpriteAndCircle()
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
    }

    private void ShiftLevers()
    {
        if(shiftLeverA)
        {
            other_lever_a.ChangeSpriteAndCircle();
            other_lever_a.SetLeverUp(!other_lever_a.isLeverUp());
        }

        if(shiftLeverB)
        {
            other_lever_b.ChangeSpriteAndCircle();
            other_lever_b.SetLeverUp(!other_lever_b.isLeverUp());
        }

        this.leverDoor.CheckLevers();
    }

    public void SetLeverUp(bool isLeverUp)
    {
        this.isUp = isLeverUp;
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
