using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueLayer : MonoBehaviour
{
    private CanvasGroup cg;
    public float duration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        DialogueEditor.ConversationManager.OnConversationStarted += IncreaseAlpha;
        DialogueEditor.ConversationManager.OnConversationEnded += DecreaseAlpha;
    }

    void OnDisable() {
        DialogueEditor.ConversationManager.OnConversationStarted -= IncreaseAlpha;
        DialogueEditor.ConversationManager.OnConversationEnded -= DecreaseAlpha;
    }

    private void IncreaseAlpha() {
        StartCoroutine(FadeCanvasGroupAlpha(1f));
    }

    private void DecreaseAlpha() {
        StartCoroutine(FadeCanvasGroupAlpha(0f));
    }

    IEnumerator FadeCanvasGroupAlpha(float endAlpha)
    {
        float startAlpha = cg.alpha;
        float progress = 0f;

        while (progress < 1f)
        {
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
            progress += Time.deltaTime / duration;

            yield return null;
        }

        cg.alpha = endAlpha;
    }
}
