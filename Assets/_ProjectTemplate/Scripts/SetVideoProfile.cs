using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DropdownType
{
    VideoProfile,
    Quality
}

public class SetVideoProfile : MonoBehaviour
{
    [SerializeField] private DropdownType _dropdownType;
    private TMP_Dropdown _myDropDown;

    private VideoController _videoController;

    private void Start()
    {
        _videoController = FindObjectOfType<VideoController>();
        _myDropDown = GetComponent<TMP_Dropdown>();

        _myDropDown.onValueChanged.AddListener(SetDropDown);        
    }

    private void SetDropDown(int value)
    {
        switch (_dropdownType)
        {
            case DropdownType.VideoProfile:
                _videoController.SetProfile(value);
                break;
            case DropdownType.Quality:
                _videoController.SetQuality(value);
                break;
        }
    }
}