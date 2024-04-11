using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private float duration = 1f;
    
    private void OnTriggerEnter(Collider other)
    {
        //canvasGroup.alpha = 0;
        //canvasGroup.interactable = true;
        //canvasGroup.blocksRaycasts = true;
        if (other.CompareTag("Player"))
        {
            canvasGroup.gameObject.SetActive(true);
            LeanTween.alphaCanvas(canvasGroup, 1, duration).setEase(LeanTweenType.easeInOutQuad);
            Debug.Log("done");
            
        }
        
    }
    
}
