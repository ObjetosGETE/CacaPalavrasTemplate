using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPositionFix : MonoBehaviour
{
    private float _correctY;
    private float _correctX;
    [SerializeField] private float _waitTime = .1f;

    private RectTransform _recTransform;

    private void Awake()
    {
        _correctY = transform.localPosition.y;
        _correctX = transform.localPosition.x;
        _recTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(_waitTime);
            _recTransform.LeanSetLocalPosY(_correctY);
            _recTransform.LeanSetLocalPosX(_correctX);
        }
    }
}
