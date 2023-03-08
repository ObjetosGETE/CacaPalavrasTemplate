using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeController : MonoBehaviour
{
    [Header("Default Volumes")]
    [SerializeField, Range(0, 1f)] private float _defaultMusicVolume;
    [SerializeField, Range(0, 1f)] private float _defaultEffecsVolume;
    [SerializeField, Range(0, 1f)] private float _defaultVoiceVolume;

    [Header("AudioMixer")]
    [SerializeField] private AudioMixer _mainMixer;

    [Header("Sliders")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Slider _voiceSlider;

    [Header("Buttons")]
    [SerializeField] private Button _restoreDefaultButton;

    private void Start()
    {
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _sfxSlider.onValueChanged.AddListener(SetEffectsVolume);
        _voiceSlider.onValueChanged.AddListener(SetVoiceVolume);

        RestoreDefault();

        _restoreDefaultButton.onClick.AddListener(RestoreDefault);     
    }

    private void RestoreDefault()
    {
        _musicSlider.value = _defaultMusicVolume;
        _sfxSlider.value = _defaultEffecsVolume;
        _voiceSlider.value = _defaultVoiceVolume;

        StartCoroutine(WaitAndSetVolume());
        IEnumerator WaitAndSetVolume()
        {
            yield return new WaitForSeconds(0.2f);
            SetMusicVolume(_musicSlider.value);
            SetEffectsVolume(_sfxSlider.value);
            SetVoiceVolume(_voiceSlider.value);
        }
    }

    private void SetVolume(string mixerName, float value)
    {
        if(value > 0)
        {
            _mainMixer.SetFloat(mixerName, Mathf.Log10(value + 0.001f) * 20f + 10);
            return;
        }
        _mainMixer.SetFloat(mixerName, -80f);
    }

    public void SetMusicVolume(float value)
    {
        SetVolume("MusicVol", value);
    }
    public void SetEffectsVolume(float value)
    {
        SetVolume("EffectVol", value);
    }
    public void SetVoiceVolume(float value)
    {
        SetVolume("VoiceVol", value);
    }
}