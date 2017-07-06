using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {

    public float autoLoadNextLevel;

    public static void LoadLevel(string Levelname) {
        Application.LoadLevel(Levelname);
    }

    void Start(){
        if (autoLoadNextLevel == 0){
            // do Nothing
        }
        else {
            Invoke("LoadNextLevel", autoLoadNextLevel);
        }
    }

    void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

}
