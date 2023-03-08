using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentDoc : MonoBehaviour
{
    public float desiredY = 0f;
    private RectTransform _myRect;

    private void Awake()
    {
        _myRect = GetComponent<RectTransform>();
    }

    public void AdjustYPos()
    {
        _myRect.LeanSetLocalPosY(desiredY);
    }
}
