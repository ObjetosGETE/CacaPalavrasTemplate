using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using System.Collections;

[RequireComponent(typeof(Button))]
public class CloseModalWindow : MonoBehaviour
{
    [SerializeField] private Animator _modalWindowAnimator;
    private Button _button;

    public AssetReference addressable;


    private void Awake()
    {
        _button = GetComponent<Button>();
        AddCloseListener();
    }

    private IEnumerator Test()
    {
        var loadHandle = addressable.LoadAssetAsync<AudioClip>();
        while (!loadHandle.IsDone)
        {
            yield return new WaitForEndOfFrame();
        }
        var addressableClip = loadHandle.Result;
        //AudioSource.clip = addressableClip; // then play it
    }

    public void AddCloseListener()
    {
        _button.onClick.AddListener(() => {
            _modalWindowAnimator.Play("FadeOut");
        });
    }
}