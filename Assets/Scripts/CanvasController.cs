using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasController : MonoBehaviour
{
    private bool isShowing = false;
    public float loadDelay = 0;
    public UnityEvent onShow;
    public UnityEvent onHide;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf)
        {
            isShowing = true;
            onShow.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        isShowing = false;
        onHide.Invoke();
    }

    public void Show()
    {
        Invoke("showDelayed", loadDelay);
    }

    private void showDelayed()
    {
        gameObject.SetActive(true);
        isShowing = true;
        onShow.Invoke();
    }
}
