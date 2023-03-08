using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// AudioManager created by Brackeys: https://www.youtube.com/watch?v=6OT43pvUyfY&t=2s
/// </summary>
public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	public Sound[] Sounds;

	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in Sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = s.mixerGroup;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(Sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

	public void Stop(string sound)
	{
		Sound s = Array.Find(Sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		//s.source.Stop();

		StartCoroutine(FadeStop(s.source));
	}

	private IEnumerator FadeStop(AudioSource source)
    {
		while(source.volume >= 0.001f)
        {
			source.volume -= Time.deltaTime;
			yield return null;
        }
		source.Stop();
    }
}