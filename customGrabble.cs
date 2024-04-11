using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class customGrabble : XRGrabInteractable
{
    private float duration = 1f;
    public CanvasGroup uiOfStick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        uiOfStick = GetComponent<CanvasGroup>();
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        uiOfStick.gameObject.SetActive(true);
        LeanTween.alphaCanvas(uiOfStick, 1, duration).setEase(LeanTweenType.easeInOutQuad);
        Debug.Log("done");
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        LeanTween.alphaCanvas(uiOfStick, 0, duration).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            uiOfStick.gameObject.SetActive(false);

        });
    }
}
