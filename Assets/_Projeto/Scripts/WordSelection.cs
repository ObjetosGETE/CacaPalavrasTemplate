using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class WordSelection : MonoBehaviour
{
    
    private TextMeshProUGUI _textRef;

    private StringBuilder _currentSelection;

    private bool _isSelecting;

    private void Start()
    {
        _currentSelection = new StringBuilder();
        _textRef = GetComponent<TextMeshProUGUI>();
        _isSelecting = false;
    }

    public void SelectionStarted()
    {
        _isSelecting = true;
    }

    private void Update()
    {
        if (!_isSelecting)
        {
            return;
        }



        if(Input.GetMouseButtonUp(0))
        {
            
        }
    }

}
