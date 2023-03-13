using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoardGenerator))]
public class BoardInstantiator : MonoBehaviour
{

    [SerializeField] private SettingsObject gameData;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private WordSelection wordSelection;


    private string[,] _boardRef;

    private void Start()
    {
        _boardRef = GetComponent<BoardGenerator>().GetBoard();

        DestroyAllChildren();

        InstantiateBoard();

    }
    

    private void DestroyAllChildren()
    {
        while (transform.childCount > 0) 
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    private void InstantiateBoard()
    {
        for (int i = 0; i < gameData.boardSize; i++)
        {
            var newRow = Instantiate(rowPrefab,Vector3.zero,Quaternion.identity,transform);
            newRow.name = i.ToString();
            for (int j = 0; j < gameData.boardSize; j++)
            {
                var newLetter = Instantiate(letterPrefab,Vector3.zero,Quaternion.identity,newRow.transform);
                newLetter.name = j.ToString();
                newLetter.GetComponentInChildren<TextMeshProUGUI>().text = _boardRef[i,j];
                newLetter.GetComponentInChildren<Letter>().SetPoint(new Vector2Int(i, j)).SetWordSelectionReference(wordSelection);
            }
        }
    }



}
