using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManger : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY    = "difficulty";
    const string SFX_KEY           = "SFX_volume";

    // Music Sound level
    public static void SetMasterVolume(float volume) {
        if (volume > 0f && volume < 100f){
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else {
            Debug.LogError("Error Master Volume out of range.");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    // Difficulty Level
    public static void SetDifficulty(float difficulty) {
        if (difficulty > 0.9f && difficulty <= 3.1f){
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else {
            Debug.LogError("An error occured trying to change diffculty");
        }
    }

    public static float GetDifficulty(){
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    // SFX sound Level

    public static void SetSFX(float SFX) {
        if (SFX > 0.1f && SFX <= 3.1f){
            PlayerPrefs.SetFloat(SFX_KEY, SFX);
        }
        else {
            Debug.LogError("Error occured when trying to make a change to SFX");
        }
    }

    public static float GetSFX() {
        return PlayerPrefs.GetFloat(SFX_KEY);
    }
}
