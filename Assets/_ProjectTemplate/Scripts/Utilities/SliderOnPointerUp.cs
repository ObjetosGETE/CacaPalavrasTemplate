using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderOnPointerUp : MonoBehaviour, IPointerUpHandler
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AudioManager.Instance.Play("Effect");
    }
}