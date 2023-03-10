using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData")]
public class SettingsObject : ScriptableObject
{
    public string[] words;
    public int boardSize;
    public bool diagonal;
}
