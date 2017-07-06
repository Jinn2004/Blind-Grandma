using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMechanics : MonoBehaviour {

    // Best ratio for a isometric design or pretty close.
    public float speedX = 2.75f;
    public float speedY = 1f;

    public GameObject carPreFab;
    public int randomNumber;

    void Start() {
     // Give a random number 0 - 7
     randomNumber = Random.Range(0, 7);
        if (randomNumber == 0 || randomNumber == 1) {
            // Up and Right
            transform.rotation = Quaternion.Euler(0, 0, 45);
        } else if (randomNumber == 4 || randomNumber == 5) {
            // Up and Left
            transform.rotation = Quaternion.Euler(0, 0, 135);
        } else if (randomNumber == 6 || randomNumber == 7) {
            // Down and Right
            transform.rotation = Quaternion.Euler(0, 0, 225);
        } else if (randomNumber == 2 || randomNumber == 3) {
            // Down and Right
            transform.rotation = Quaternion.Euler(0, 0, -45);
        } else {
            Debug.LogError("Your random number was outside of 0-7");
        }

        SpawnCars();
    }

    void SpawnCars(){
        // Access the transform to 
        foreach (Transform child in transform){
            // Spawn a car
            GameObject car = Instantiate(carPreFab, child.transform.position, Quaternion.identity) as GameObject;
            // spawn the car as a child of the car formation
            car.transform.parent = child;
        }
    }

    void MoveCars() {
        if (randomNumber == 0 || randomNumber == 1){
            // Move UpRight
            transform.position += new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        } else if (randomNumber == 2 || randomNumber == 3){
            // Move DownRight
            transform.position += new Vector3(speedX * Time.deltaTime, -speedY * Time.deltaTime, 0);
        } else if (randomNumber == 4 || randomNumber == 5){
            // Move UpLeft
            transform.position += new Vector3(-speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        } else if (randomNumber == 6 || randomNumber == 7){
            // Move DownLeft
            transform.position += new Vector3(-speedX * Time.deltaTime, -speedY * Time.deltaTime, 0);
        }

    }

    void Update(){

        // Move the cars to the Left?
        MoveCars();

        // Check to see if need to spawn more cars
        if (AllCarsDead()) {
            SpawnCars();
        }
    }

    bool AllCarsDead() {
        foreach (Transform childPositionGameObject in transform){
            if (childPositionGameObject.childCount > 0) {
                return false;
            }
        }
        return true;
    }
}
