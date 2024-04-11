using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasLeanTween : MonoBehaviour
{
    private float duration = 1f;
    public CanvasGroup UI;

    // Start is called before the first frame update
    public void Start()
    {
        CanvasGroup UI = GetComponent<CanvasGroup>();
        UI.alpha = 0;
        UI.interactable = true;
        UI.blocksRaycasts = true;
        LeanTween.alphaCanvas(UI, 1, duration).setEase(LeanTweenType.easeInOutQuad);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseUI()
    {
        LeanTween.alphaCanvas(UI, 0, duration).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                UI.interactable = false;
                UI.blocksRaycasts = false;
                UI.gameObject.SetActive(false);

            });
        
    }
}
