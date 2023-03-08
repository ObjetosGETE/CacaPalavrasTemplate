using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class InfoPanel : MonoBehaviour
{
    [Header("UI Refferences")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _contentText;

    [Header("Content Object")]
    [SerializeField] private ContentScriptableObject _myContent;

    public ContentScriptableObject Content { get { return _myContent; } }

    private void Awake()
    {
        SetContent(_myContent);
    }

    public void SetContent(ContentScriptableObject content)
    {
        _myContent = content;
        if (_titleText)
        {
            _titleText.SetText(content.Title);
        }
        else
        {
            Debug.LogWarning("This Info Panel does not seen to have a title.");
        }
        if (_contentText)
        {
            _contentText.SetText(content.Content);
        }
        else
        {
            Debug.LogWarning("This Info Panel does not seen to have content.");
        }
    }
}