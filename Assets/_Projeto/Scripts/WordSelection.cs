using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class WordSelection : MonoBehaviour
{

    [SerializeField] private BoardObject boardData;
    [SerializeField] private SettingsObject settingsObject;
    [SerializeField] private WordList wordList;


    private TextMeshProUGUI _textRef;

    private StringBuilder _currentSelection;

    private Vector2Int _initialClick, _secondClick;

    private bool _isSelecting;

    private void Start()
    {
        _currentSelection = new StringBuilder();
        _textRef = GetComponent<TextMeshProUGUI>();
        _isSelecting = false;
        _initialClick = new Vector2Int(-1, -1);
        _secondClick = new Vector2Int(-2, -2);
        
    }

    private bool CheckWord(string word)
    {
        foreach (var t in settingsObject.words)
        {
            if (t.ToUpper().Equals(word))
            {
                Debug.Log("Acerto! -> " + word);
                return true;
            }
        }

        return false;
    }
    
    //USANDO STRING PARA INDEX -> MUDAR ASSIM QUE POSSÌVEL
    public void OnLetterSelected(Vector2Int p)
    {

        if (_isSelecting)
        {
            _secondClick = p;
            if (OnTheSameLine(_initialClick, _secondClick))
            {
                var range = BoardObject.GetLineBetweenPoints(_initialClick,_secondClick);

                _currentSelection.Clear();
                foreach (var v in range)
                {
                    _currentSelection.Append(boardData.Board[v.x, v.y]);
                }
                _textRef.text = _currentSelection.ToString();
                if(CheckWord(_currentSelection.ToString()))
                {
                    wordList.StrikeAnswer(_currentSelection.ToString());
                    _isSelecting = false;
                    _textRef.text = "";
                }
            }
            else
            {
                _isSelecting = false;
                _textRef.text = "";
            }
        }
        else
        {
            _initialClick = p;                
            _currentSelection.Clear();
            _currentSelection.Append(boardData.Board[p.x, p.y]);
            _textRef.text = _currentSelection.ToString();
            _isSelecting = true;
        }

        if (_secondClick.Equals(_initialClick))
        {
            _isSelecting = false;
            _textRef.text = "";
        }
    }
    
    
    
    private bool OnTheSameLine(Vector2Int p1, Vector2Int p2)
    {
        return p1.x == p2.x || p1.y == p2.y;
    }
    
}
