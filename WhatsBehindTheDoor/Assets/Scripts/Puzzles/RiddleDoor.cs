using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RiddleDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openViewframeSprite;

    [Header("Canvas")]
    [SerializeField] GameObject openViewFrameButton;
    [SerializeField] GameObject riddleCanvas;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI guardResponseText;

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

    public void CheckAnswer(string s)
    {
        string answer = s;
        if(answer != "please")
        {
            StartCoroutine(GuardAnswer("Wrong..."));
        } 
        else
        {
            StartCoroutine(GuardAnswer("Very well, you may enter..."));
            //unlock door
        }
    }

    IEnumerator GuardAnswer(string guardAnswer)
    {
        this.guardResponseText.text = guardAnswer;
        yield return new WaitForSeconds(4);
        this.guardResponseText.text = "";
    }
}
