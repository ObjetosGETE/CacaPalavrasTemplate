using UnityEngine;

/// <summary>
/// Add this to the Main Canvas to auto assign a camera to it.
/// </summary>
[RequireComponent(typeof(Canvas))]
public class AutoAssignMainCameraToCanvas : MonoBehaviour
{
    private Canvas _myCanvas;

    private void Start()
    {
        _myCanvas = GetComponent<Canvas>();

        if (_myCanvas.worldCamera != null)
            return;

        else if (!Camera.main)
        {
            Debug.LogError("This script requires a Camera with 'MainCamera' tag to be present on the scene");
            return;
        }

        _myCanvas.worldCamera = Camera.main;
    }
}