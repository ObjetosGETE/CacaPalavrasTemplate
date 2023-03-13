using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEvent",menuName = "NewGameEvent")]
public class SelectLetterEvent : ScriptableObject
{
    public List<SelecLetterListener> listeners = new();
    

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(SelecLetterListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(SelecLetterListener listener)
    {
        listeners.Remove(listener);
    }
    
}
