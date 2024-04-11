using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeUI : MonoBehaviour
{
    private float duration = 1f;
    public CanvasGroup UI;
    private float delay = 5f;
    public CanvasGroup nextUI;
    public void CloseUI()
    {
        LeanTween.alphaCanvas(UI, 0, duration).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            UI.interactable = false;
            UI.blocksRaycasts = false;
            UI.gameObject.SetActive(false);

        });
    }

    public void OpenAnotherUI()
    {
        StartCoroutine(DelayedOpenUI());
    }
    private IEnumerator DelayedOpenUI()
    {
        Debug.Log("Waiting for 5 seconds before opening next UI");
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Ensure the UI is ready to be made visible
        nextUI.alpha = 0;
        nextUI.interactable = false;
        nextUI.blocksRaycasts = false;

        // Now activate the UI gameObject and start the fade-in effect
        nextUI.gameObject.SetActive(true);
        LeanTween.alphaCanvas(nextUI, 1, duration).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            // Once the fade in is complete, make the UI interactable
            nextUI.interactable = true;
            nextUI.blocksRaycasts = true;
            Debug.Log("Next UI is now open and interactable");
        });

    }
}
