using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour {

    public AudioClip[] levelMusicArray;
    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    void OnLevelWasLoaded(int level) {
		if (level == 1) {
			AudioClip thisLevelMusic = levelMusicArray [0];
			if (thisLevelMusic) {
				audioSource.clip = thisLevelMusic;
				audioSource.loop = true;
				audioSource.Play ();
			}
		}
    }

    public void ChangeVolume(float volume) {
        audioSource.volume = volume;
    }
}
