using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class AutoPopulateToggleGroup : MonoBehaviour
{
    private ToggleGroup _myToggleGroup;
    private Toggle[] _toggleArray;

    private void Awake()
    {
        _myToggleGroup = GetComponent<ToggleGroup>();
        _toggleArray = GetComponentsInChildren<Toggle>(true);
        Populate();
        return;
    }

    private void Populate()
    {
        foreach (var t in _toggleArray)
        {
            _myToggleGroup.RegisterToggle(t);
        }
        _myToggleGroup.SetAllTogglesOff();
        _myToggleGroup.EnsureValidState();
    }
}
