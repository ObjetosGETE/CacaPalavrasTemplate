using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LetterData", menuName = "ScriptableObjects/LetterData")]
public class LetterObject : ScriptableObject
{
    public float letterSize;
    public Color letterColor;
    public float height;
    public float width;

    [HideInInspector] public UnityEvent onChanged;
    
    private void OnValidate()
    {
        onChanged.Invoke();
    }
}
