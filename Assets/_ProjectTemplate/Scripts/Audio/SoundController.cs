using System;
using UnityEngine;
using UnityEngine.Audio;

/*
 ################------SOUND CONTROLLER-------################

Esse script gerência o controle das musicas e efeitos sonoros do jogo
Gameobjects que contenham algum efeito sonoro devem ter a tag "AudioEffect"
Gameobjects que contenham alguma musica devem ter a tag "AudioMusic"

O GameManager gerência chamadas externas para esse script 

 #############################################################
 */

public class SoundController : MonoBehaviour
{
    #region VAR
    private float currentEffectLevel;
    private float currentMusicLevel;

    public AudioMixer masterMixer;
    #endregion

    public void StartMain()
    {
        SetEffectLevel(0.7f);
        SetMusicLevel(0.7f);
    }

    #region STEREO/MONO

    static int[] validSpeakerModes =
{
        (int)AudioSpeakerMode.Mono,
        (int)AudioSpeakerMode.Stereo
    };

    //altera o audiosettings -> MONO: value = 0 / STEREO: value = 1
    
    public void SetSpeakerMode(int p_value)
    {
        GameObject[] _objEffects;
        bool[] _isPlayingEffect;

        GameObject[] _objMusic;
        bool[] _isPlayingMusic;

        _objEffects = GameObject.FindGameObjectsWithTag("AudioEffect");
        _isPlayingEffect = new bool[_objEffects.Length];
        for (int i = 0; i < _objEffects.Length; i++)
            _isPlayingEffect[i] = _objEffects[i].GetComponent<AudioSource>().isPlaying;

        _objMusic = GameObject.FindGameObjectsWithTag("AudioMusic");
        _isPlayingMusic = new bool[_objMusic.Length];
        for (int i = 0; i < _objMusic.Length; i++)
            _isPlayingMusic[i] = _objMusic[i].GetComponent<AudioSource>().isPlaying;

        AudioConfiguration config = AudioSettings.GetConfiguration();
        config.speakerMode = (AudioSpeakerMode)validSpeakerModes[p_value];
        AudioSettings.Reset(config);

        //obrigatóriamente chamado para reiniciar todos os audios após a mudança de saída de audio
        ResetAudios(_objEffects, _isPlayingEffect);
        ResetAudios(_objMusic, _isPlayingMusic);
    }

    internal void RestoreDefaultSettings()
    {
        SetEffectLevel(0.7f);
        SetMusicLevel(0.7f);
    }

    private void ResetAudios(GameObject[] p_obj, bool[] p_isPlaying)
    {
        for (int i = 0; i < p_obj.Length; i++)
        {
            p_obj[i].GetComponent<AudioSource>().enabled = false;
            p_obj[i].GetComponent<AudioSource>().enabled = true;

            if (p_isPlaying[i])
                p_obj[i].GetComponent<AudioSource>().Play();
            else
                p_obj[i].GetComponent<AudioSource>().Stop();
        }
    }
    #endregion

    #region MUSIC
    //altera o volume das musicas conforme o valor passado como parametro 0.0001f / 1
    
    public void SetMusicLevel(float p_value)
    {
        currentMusicLevel = p_value;
        if (p_value < 0.01f)
        {
            masterMixer.SetFloat("MusicVol", -80f);
            return;
        }
        masterMixer.SetFloat("MusicVol", Mathf.Log10(currentMusicLevel) * 20f);
    }

    #endregion

    #region SOUND EFFECTS 
    //altera o volume das musicas conforme o valor passado como parametro -80/20
    
    public void SetEffectLevel(float p_value)
    {
        currentEffectLevel = p_value;
        if (p_value < 0.01f)
        {
            masterMixer.SetFloat("EffectVol", -80f);
            return;
        }
        masterMixer.SetFloat("EffectVol", Mathf.Log10(currentEffectLevel) * 20f);
    }
    
    #endregion
}