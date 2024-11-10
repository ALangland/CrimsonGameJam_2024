using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TyperTextBox : MonoBehaviour
{
    private TextMeshProUGUI textbox;
    private AudioSource audioSource;
    private int currentCharacterIndex = 0;
    private WaitForSeconds initialDelay;
    private WaitForSeconds characterDelay;
    private WaitForSeconds slowCharacterDelay;
    private WaitForSeconds inputCharDelay;
    private bool isTyping = false;
    private bool slowTyping = false;

    private Coroutine typingCoroutine;
    private Coroutine inputCharCoroutine;

    public float charactersPerSecond = 0;
    public float slowCharactersPerSecond = 0;
    public float inputCharSpeed = 2;
    public string fullText = string.Empty;
    public float initialDelayTime = 0;
    public AudioClip typingSound;
    public UnityEvent typingCompleted;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void onShow()
    {
        textbox = GetComponent<TextMeshProUGUI>();
        audioSource = GameObject.Find("SfxPlayer").GetComponent<AudioSource>();
        characterDelay = new WaitForSeconds(1.0f / charactersPerSecond);
        slowCharacterDelay = new WaitForSeconds(1.0f / slowCharactersPerSecond);
        inputCharDelay = new WaitForSeconds(1.0f / inputCharSpeed);
        initialDelay = new WaitForSeconds(initialDelayTime);
        textbox.text = string.Empty;
        typingCoroutine = StartCoroutine(StartTyping());
        inputCharCoroutine = StartCoroutine(BlinkingCursor());
    }

    private IEnumerator StartTyping()
    {
        yield return initialDelay;
        isTyping = true;
        while (currentCharacterIndex < fullText.Length)
        {
            if (textbox.text.EndsWith("_"))
            {
                textbox.text = textbox.text.TrimEnd('_');
            }
            if (fullText.Substring(currentCharacterIndex).StartsWith("[slow]"))
            {
                slowTyping = true;
                currentCharacterIndex += "[slow]".Length;
                continue;
            }
            else if (fullText.Substring(currentCharacterIndex).StartsWith("[normal]"))
            {
                slowTyping = false;
                currentCharacterIndex += "[normal]".Length;
                continue;
            }
            textbox.text += fullText[currentCharacterIndex];
            audioSource.PlayOneShot(typingSound);
            currentCharacterIndex++;
            textbox.text += "_";
            yield return slowTyping ? slowCharacterDelay : characterDelay;
        }
        isTyping = false;
        typingCompleted.Invoke();
    }

    private IEnumerator BlinkingCursor()
    {
        while (isActiveAndEnabled)
        {
            if (!isTyping)
            {
                if (!textbox.text.EndsWith("_"))
                {
                    textbox.text += "_";
                }
                yield return inputCharDelay;
                textbox.text = textbox.text.TrimEnd('_');
                yield return inputCharDelay;
            }
            else
            {
                yield return null;
            }
        }
    }
}
