using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGreenButton : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    [SerializeField] private Sprite firstButtonImage;
    [SerializeField] private Sprite secondButtonImage;
    [SerializeField] private LittleGreenButton[] littleGreenButtons;
    [SerializeField] private AudioClip[] sentences;
    [SerializeField] private bool pushed;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (audioSource.clip != null && !audioSource.isPlaying && !pushed)
        {
            spriteRenderer.sprite = secondButtonImage;
            pushed = true;
            audioSource.Play();
            if (littleGreenButtons != null)
            {
                foreach (LittleGreenButton greenButton in littleGreenButtons)
                {
                    RestartAnotherButtons(greenButton);
                }
            }
        }
    }

    void RestartAnotherButtons(LittleGreenButton greenButton)
    {
        greenButton.spriteRenderer.sprite = greenButton.firstButtonImage;
        greenButton.pushed = false;
    }

    public AudioClip[] GetSentences()
    {
        return sentences;
    }

    public bool GetPushed()
    {
        return pushed;
    }

}
