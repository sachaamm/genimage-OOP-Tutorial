using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour
{
    public GameObject carPrefab, boatPrefab;

    Car car;
    Boat boat;

    // Start is called before the first frame update
    void Start()
    {
        int vitesseVoiture = 10;
        int vitesseBateau = 2;

        Vector3 carPos = new Vector3(0, 0, 0);
        Vector3 boatPos = new Vector3(3, 0, 0);

        car = new Car(vitesseVoiture, Instantiate(carPrefab, carPos , Quaternion.identity));
        boat = new Boat(vitesseBateau, Instantiate(boatPrefab, boatPos , Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {
        car.Move();
        car.Signaux();

        boat.Move();
        boat.Signaux();
    }
}
