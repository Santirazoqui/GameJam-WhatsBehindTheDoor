using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RiddleDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openViewframeSprite;
    [SerializeField] Door riddleDoor;

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
        string answer = s.ToLower();
        if(answer != "please")
        {
            StartCoroutine(GuardAnswer("Wrong..."));
        } 
        else
        {
            StartCoroutine(GuardAnswer("Very well, you may enter..."));
            Destroy(this.riddleCanvas, 4f);
            this.riddleDoor.SetLocked(false);
        }
    }

    IEnumerator GuardAnswer(string guardAnswer)
    {
        this.guardResponseText.text = guardAnswer;
        yield return new WaitForSeconds(4);
        this.guardResponseText.text = "";
    }
}
