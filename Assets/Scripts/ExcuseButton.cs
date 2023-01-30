using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcuseButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    [SerializeField] private Sprite firstButtonImage;
    [SerializeField] private Sprite secondButtonImage;
    [SerializeField] private LittleGreenButton[] littleGreenButtons;

    private LittleGreenButton actualGreenButton;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (littleGreenButtons != null)
        {
            foreach (LittleGreenButton greenButton in littleGreenButtons)
            {
                if (greenButton.GetPushed())
                {
                    actualGreenButton = greenButton;
                    break;
                }
            }
        }
    }

    void Update()
    {
        if (actualGreenButton != null && !actualGreenButton.GetPushed() && littleGreenButtons != null)
        {
            foreach (LittleGreenButton greenButton in littleGreenButtons)
            {
                if (greenButton.GetPushed())
                {
                    actualGreenButton = greenButton;
                    break;
                }
            }
        }
    }

    void OnMouseDown()
    {
        AudioClip sentence = null;
        if (actualGreenButton.GetSentences() != null)
        {
            int indexAudioClip = Random.Range(0, actualGreenButton.GetSentences().Length);
            sentence = actualGreenButton.GetSentences()[indexAudioClip];
        }

        if (sentence != null && !audioSource.isPlaying)
        {
            spriteRenderer.sprite = secondButtonImage;
            StartCoroutine(playSound(sentence));
        }
    }

    IEnumerator playSound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
        yield return new WaitForSeconds(audio.length);
        spriteRenderer.sprite = firstButtonImage;
    }

}
