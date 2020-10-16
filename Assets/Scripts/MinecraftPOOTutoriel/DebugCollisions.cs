using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script permettant de debugger les collisions sur le joueur
public class DebugCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Block")
        {
            Debug.Log("player collided with " + collision.gameObject.name);
        }
        
    }
}
