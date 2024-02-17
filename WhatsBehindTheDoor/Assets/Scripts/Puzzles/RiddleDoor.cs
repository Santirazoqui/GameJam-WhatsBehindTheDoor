using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openViewframeSprite;
    [SerializeField] GameObject openViewFrameButton;
    [SerializeField] GameObject riddleCanvas;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OpenViewFrame()
    {
        this.spriteRenderer.sprite = openViewframeSprite;
        this.openViewFrameButton.SetActive(false);
        this.riddleCanvas.SetActive(true);
    }
}
