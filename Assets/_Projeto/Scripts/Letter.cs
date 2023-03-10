using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class Letter : MonoBehaviour
{
    [SerializeField] private LetterObject data;

    private RectTransform _rtRef;
    private TextMeshProUGUI _tmpRef;

    private void Start()
    {
        _tmpRef = GetComponent<TextMeshProUGUI>();
        _rtRef = GetComponent<RectTransform>();
        data.onChanged.AddListener(UpdateSettings);
        UpdateSettings();
    }

    private void UpdateSettings()
    {
        _tmpRef.color = data.letterColor;
        _tmpRef.fontSize = data.letterSize;
        _rtRef.sizeDelta = new Vector2(data.width, data.height);
    }
    
}
