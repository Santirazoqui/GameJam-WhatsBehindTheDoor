using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    [SerializeField] List<Sprite> windowBreakSteps;
    private int currentStep = 0;

    [SerializeField] GameObject breakWindowButton;

    [Header("Audio")]
    [SerializeField] AudioClip breakGlassClip;
    [SerializeField] [Range(0f, 1f)] float breakGlassVolume = 0.2f;
    [SerializeField] List<AudioClip> glassBreakAudioClips;

    private SpriteRenderer spriteRenderer;
    private AudioPlayer audioPlayer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void BreakWindow()
    {
        if(currentStep < windowBreakSteps.Count)
        {
            spriteRenderer.sprite = windowBreakSteps[currentStep];
            this.audioPlayer.PlayClip(glassBreakAudioClips[currentStep], 0.2f);
            currentStep++;
        }

        if(currentStep == windowBreakSteps.Count)
        {
            breakWindowButton.SetActive(false);
        }
    }
}
