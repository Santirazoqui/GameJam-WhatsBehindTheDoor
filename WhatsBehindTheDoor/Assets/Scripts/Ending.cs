using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject cake;
    [SerializeField] ParticleSystem explosionEffect;

    [Header("UI")]
    [SerializeField] GameObject cakeButton;
    [SerializeField] GameObject finishText;
    [SerializeField] GameObject thankYouText;

    [Header("Audio")]
    [SerializeField] AudioClip explosionClip;
    private AudioPlayer audioPlayer;

    void Awake()
    {
        this.audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    // Start is called before the first frame update
    public void EatCake()
    {
        cake.SetActive(false);
        cakeButton.SetActive(false);
        this.Explode();
    }

    void Explode()
    {
        this.audioPlayer.PlayClip(this.explosionClip, 0.2f);
        ParticleSystem instance = Instantiate(explosionEffect, cake.transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        this.finishText.SetActive(false);
        this.thankYouText.SetActive(true);
    }
}
