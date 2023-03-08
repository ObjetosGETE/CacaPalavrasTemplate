using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvasGroup : MonoBehaviour
{
    public static ToggleCanvasGroup Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ToggleIn(CanvasGroup toToggle,  bool instant = false)
    {
        Toggle(toToggle, true, instant);
    }
    public void ToggleOff(CanvasGroup toToggle, bool instant = false)
    {
        Toggle(toToggle, false, instant);
    }

    public void ToggleIn(Popup toToggle, bool instant = false)
    {
        ToggleIn(toToggle.GetComponent<CanvasGroup>(), instant);
    }
    public void ToggleOff(Popup toToggle, bool instant = false)
    {
        ToggleOff(toToggle.GetComponent<CanvasGroup>(),  instant);
    }

    private void Toggle(CanvasGroup toToggle, bool value, bool instant = false)
    {
        if (instant)
        {
            float alpha = value ? 1 : 0;
            toToggle.alpha = alpha;
        }
        else
        {
            StartCoroutine(FadeCanvas(toToggle, !value));
        }
        toToggle.interactable = value;
        toToggle.blocksRaycasts = value;
    }

    private IEnumerator FadeCanvas(CanvasGroup group, bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                group.alpha = i;
                yield return null;
            }
            group.alpha = 0;
            group.gameObject.SetActive(false);
        }

        else
        {
            group.gameObject.SetActive(true);
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                group.alpha = i;
                yield return null;
            }
            group.alpha = 1;
        }
    }
}
