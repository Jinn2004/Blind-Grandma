using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLeft : MonoBehaviour {

    // Best ratio for a isometric design or pretty close.
    public float speedX = 2.75f;
    public float speedY = 1f;

    public GameObject carPreFab;

    void Start()
    {
        // Down and Right
        transform.rotation = Quaternion.Euler(0, 0, 225);
        SpawnCars();
    }

    void SpawnCars()
    {
        // Access the transform to 
        foreach (Transform child in transform)
        {
            // Spawn a car
            GameObject car = Instantiate(carPreFab, child.transform.position, Quaternion.identity) as GameObject;
            // spawn the car as a child of the car formation
            car.transform.parent = child;
        }
    }

    void MoveCars()
    {
        // Move DownLeft
        transform.position += new Vector3(-speedX * Time.deltaTime, -speedY * Time.deltaTime, 0);
    }

    void Update()
    {

        // Move the cars to the Left?
        MoveCars();

        // Check to see if need to spawn more cars
        if (AllCarsDead())
        {
            SpawnCars();
        }
    }

    bool AllCarsDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}
