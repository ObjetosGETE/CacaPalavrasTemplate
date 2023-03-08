using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScene : MonoBehaviour
{
    public void Play(string audio)
    {
        AudioManager.Instance.Play(audio);
    }

    public void Stop(string audio)
    {
        AudioManager.Instance.Stop(audio);
    }
}
