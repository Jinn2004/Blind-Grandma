using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public Slider SFXSlider;

    public levelManager levelManager;

    private musicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindObjectOfType<musicManager>();
        volumeSlider.value     = PlayerPrefsManger.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManger.GetDifficulty();
        //SFXSlider.value        = PlayerPrefsManger.GetSFX();

    }

    // Update is called once per frame
    void Update () {
        musicManager.ChangeVolume(volumeSlider.value);
        //musicManager.ChangeVolume(volumeSlider.value;)
        //musicManager.ChangeVolume(volumeSlider.value;)

	}

    void SetDefaults() {
        difficultySlider.value = 2f;
        volumeSlider.value = 0.5f;
        SFXSlider.value = 0.5f;
    }

    public void Save() {
        PlayerPrefsManger.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManger.SetDifficulty(difficultySlider.value);
        PlayerPrefsManger.SetSFX(SFXSlider.value);
        levelManager.LoadLevel("Start");
    }
}
