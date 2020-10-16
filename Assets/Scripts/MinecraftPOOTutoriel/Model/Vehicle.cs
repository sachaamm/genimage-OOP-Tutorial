using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public abstract class Vehicle
{
    public float speed;
    GameObject vehicleGameObject;

    public Vehicle(float speed, GameObject prefab)
    {
        this.speed = speed;
        this.vehicleGameObject = prefab;        
    }

    public void Move()
    {
        Vector3 forward = vehicleGameObject.transform.forward;
        vehicleGameObject.transform.Translate(forward * speed * Time.deltaTime);
    }

    public abstract void Signaux();
   
}

public class Car : Vehicle
{
    Light light;
    double compteurClignotement;
    static int clignotementsSteps = 120; // 12 valeurs d'intensité différentes
    double angleIncrementation = Math.PI * 2 / clignotementsSteps;

    public Car(float speed, GameObject prefab) : base(speed, prefab)
    {
        // assigne light
        light = prefab.GetComponentInChildren<Light>();
    }

    public override void Signaux()
    {
        // un feu clignotant
        compteurClignotement+= angleIncrementation;      
        light.intensity = (float)Math.Cos(compteurClignotement); // 0 à 2PI 
    }

}

public class Boat : Vehicle
{
    AudioSource audioSource;
    int compteur;
    int delai = 100;

    public Boat(float speed, GameObject prefab) : base(speed, prefab)
    {
        audioSource = prefab.GetComponentInChildren<AudioSource>();
    }

    public override void Signaux()
    {
        // un son d'arrivée au port

        // si le son est terminé
        if (!audioSource.isPlaying)
        {
            // on incrémente le compteur
            compteur++;

            if(compteur >= delai)
            {
                compteur = 0;
                audioSource.Play();
            }

        }
    
    }
}