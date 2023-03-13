using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class WordList : MonoBehaviour
{

    [SerializeField] private SettingsObject gameData;

    private List<GameObject> _words;
    
    private void Start()
    {
        _words = new List<GameObject>();
        foreach (var w in gameData.words)
        {
            var newObj = new GameObject();
            newObj.transform.parent = transform;
            newObj.name = w;
            newObj.AddComponent<TextMeshProUGUI>().text = w;
            _words.Add(newObj);
        }
    }

    public void StrikeAnswer(string word)
    {
        foreach (var g in _words)
        {
            var w = g.name.ToUpper();
            if (w.Equals(word))
            {
                g.GetComponent<TextMeshProUGUI>().text = string.Format("<s>{0}</s>", g.name);
            }
        }
    }
    
}
