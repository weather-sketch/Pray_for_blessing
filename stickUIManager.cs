using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickUIManager : MonoBehaviour
{
    public CanvasGroup uiOfStick;
    private float duration = 1f;
    public Transform canvasTransform;
    private CanvasGroup uiOfStickInstance;


    public void InstantiateUIPrefab()
    {
        if (uiOfStick != null && canvasTransform != null)
        {
            CanvasGroup uiOfStickInstance = Instantiate(uiOfStick, canvasTransform.position, canvasTransform.rotation);
            
            RectTransform rectTransform = uiOfStickInstance.GetComponent<RectTransform>();
            uiOfStickInstance.alpha = 0;
            uiOfStickInstance.interactable = false;
            uiOfStickInstance.blocksRaycasts = false;
            Debug.Log("attempting at" + canvasTransform.position);
            uiOfStickInstance.gameObject.SetActive(true);
            LeanTween.alphaCanvas(uiOfStickInstance, 1, duration).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                uiOfStickInstance.interactable = true;
                uiOfStickInstance.blocksRaycasts = true;
            });
            Debug.Log("UIsetactive");
        }
    }
    public void CloseUI()
    {

        if (uiOfStickInstance != null)
        {
            LeanTween.alphaCanvas(uiOfStickInstance, 0, duration).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                uiOfStickInstance.gameObject.SetActive(false);
            });
        }
    }
}

