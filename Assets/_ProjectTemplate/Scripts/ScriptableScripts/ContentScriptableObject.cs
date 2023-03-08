using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ContentScriptableObject", order = 1)]
public class ContentScriptableObject : ScriptableObject
{
    public string Title;
    [TextArea(1,15)]
    public string Content;
}