using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatingProfile : MonoBehaviour
{
    private Animator bgAnimator;
    private AudioSource audioSource;
   
    public GameObject scrollView;
    public AudioClip appearSound;
    public AudioClip loadingSound;
    public float loadingDelay = 0;

    void Start()
    {
        scrollView.gameObject.SetActive(false);
        bgAnimator = GameObject.Find("DatingProfileBG").GetComponent<Animator>();
        audioSource = GameObject.Find("SfxPlayer").GetComponent<AudioSource>();
        audioSource.PlayOneShot(appearSound);
        bgAnimator.SetBool("Startup", true);
        audioSource.PlayOneShot(loadingSound);
        Invoke("LoadUp", loadingDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadUp()
    {
        bgAnimator.SetTrigger("SfxDone");
        scrollView.gameObject.SetActive(true);
    }
}
