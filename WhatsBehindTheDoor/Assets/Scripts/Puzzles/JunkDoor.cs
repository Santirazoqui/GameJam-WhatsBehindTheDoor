using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JunkDoor : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI guardResponseText;
    [SerializeField] GameObject riddleCanvas;

    private Door wallCodeDoor;

    void Awake()
    {
        this.wallCodeDoor = GetComponent<Door>();
    }

    public void CheckAnswer(string s)
    {
        string answer = s.ToLower();
        if(answer != "6342")
        {
            StartCoroutine(GuardAnswer("Wrong!"));
        } 
        else
        {
            StartCoroutine(GuardAnswer("Correct! You may pass..."));
            Destroy(this.riddleCanvas, 4f);
            this.wallCodeDoor.SetLocked(false);
        }
    }

    IEnumerator GuardAnswer(string guardAnswer)
    {
        this.guardResponseText.text = guardAnswer;
        yield return new WaitForSeconds(4);
        this.guardResponseText.text = "";
    }
}
