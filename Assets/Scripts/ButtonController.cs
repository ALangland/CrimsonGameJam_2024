using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip appearSound;
    public AudioClip clickSound;
    public float delay = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        audioSource = GameObject.Find("SfxPlayer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Appear()
    {
        Invoke("DelayedAppear", delay);
    }

    private void DelayedAppear()
    {
        gameObject.SetActive(true);
        audioSource.PlayOneShot(appearSound);
    }

    public void Click()
    {
        audioSource.PlayOneShot(clickSound);
    }


}
