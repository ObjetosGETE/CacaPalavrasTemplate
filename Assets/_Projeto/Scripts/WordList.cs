using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordList : MonoBehaviour
{

    [SerializeField] private SettingsObject gameData;
    
    private void Start()
    {
        foreach (var w in gameData.words)
        {
            var newObj = Instantiate(new GameObject(),Vector3.zero,Quaternion.identity,transform);
            newObj.AddComponent<TextMeshProUGUI>().text = w;
        }
    }

}
