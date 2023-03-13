using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class Letter : MonoBehaviour
{
    [SerializeField] private LetterObject data;

    private RectTransform _rtRef;
    private TextMeshProUGUI _tmpRef;
    private Vector2Int _point;
    private WordSelection _wordSelection;
    
    private void Start()
    {
        _tmpRef = GetComponent<TextMeshProUGUI>();
        _rtRef = GetComponent<RectTransform>();
        data.onChanged.AddListener(UpdateSettings);
        UpdateSettings();
    }

    public Letter SetPoint(Vector2Int p)
    {
        _point = p;
        return this;
    }
    
    public Letter SetWordSelectionReference(WordSelection w)
    {
        _wordSelection = w;
        return this;
    }

    private void UpdateSettings()
    {
        _tmpRef.color = data.letterColor;
        _tmpRef.fontSize = data.letterSize;
        _rtRef.sizeDelta = new Vector2(data.width, data.height);
    }

    public void OnSelected()
    {
        if (_wordSelection == null || _point == null)
        {
            return;
        }
        
        _wordSelection.OnLetterSelected(_point);
    }
    
}
