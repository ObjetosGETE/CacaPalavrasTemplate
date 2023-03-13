using UnityEngine;
using UnityEngine.Events;

public class SelecLetterListener : MonoBehaviour
{
    public SelectLetterEvent selectLetterEvent;
    public UnityEvent<Vector2Int> response;

    private void OnEnable()
    {
        selectLetterEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        selectLetterEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        //response.Invoke();
    }
}
