using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using System;

// La classe Block est la classe qui nous permet d'enregistrer les donnees relatives aux blocs de notre niveau
[Serializable] // l'attribut Serializable permet d'eregistrer nos donnees vers un fichier (Serialisation)
public class Block
{
    // définition des variables de la classe
    public int x; // position x
    public int y; // position y
    public int z; // position z

    private GameObject gameObject; 

    // Behaviours
    public bool isRotating = false;

    // Attributs optionnels
    public bool isStartingBlock = false;
    public bool isEndingBlock = false;

    // Le constructeur : méthode qui est appelé à l'instantiation de l'objet
    public Block(int x, int y, int z, GameObject prefab)
    {
        // Assignation des valeurs des variables
        this.x = x;
        this.y = y;
        this.z = z;

        // ici nous avons fait le choix d'instantier le game Object correspondant dans le constructeur
        gameObject = GameObject.Instantiate(prefab, new Vector3(x,y,z), Quaternion.identity);
        gameObject.transform.name = x + "_" + y + "_" + z;
    }

    ~Block() 
    {
        // Destructeur ( en C# finalizer ), appele au moment de la destruction de l'objet
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    // une reference vers blockPrefab

    public Vector3 GetPos()
    {
        return new Vector3(x, y, z);
    }

    // Méthode d'accession implicite ( par get et set ) : on utilise une variable publique de substitution 
    public int X
    {
        get { return x; }
        set { x = value; }
    }

    // Accesseurs explicites
    public int GetX()
    {
        return x;
    }

    public void SetX(int x)
    {
        this.x = x;
    }

}
