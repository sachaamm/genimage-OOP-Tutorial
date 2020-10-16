using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

// script de deplacement de la camera
public class MoveCamera : MonoBehaviour
{
    float moveSpeed = 0.1f;
    Game game;
    LevelIO levelIO;

    // Start is called before the first frame update
    void Start()
    {
        game = GetComponentInChildren<Game>();
        levelIO = GetComponentInChildren<LevelIO>();
    }

    // Update is called once per frame
    void Update()
    {
        // si on est en train de saisir le nom du niveau a sauver on arrete Update via return
        if (levelIO.isTypingLevelToSave)
        {
            return;
        }

        if(game.GetCurrentGameState() == Game.GameState.IN_GAME)
        {
            return; // Bloquer l'execution de la fonction a cet endroit
        }

        if (Input.GetKey(Shortcuts.leftRotateCameraKey))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }

        if (Input.GetKey(Shortcuts.rightRotateCameraKey))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }

        if (Input.GetKey(Shortcuts.moveForwardCameraKey))
        {
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed);
        }

        if (Input.GetKey(Shortcuts.moveBackwardCameraKey))
        {
            transform.Translate(new Vector3(0, 0, -1) * moveSpeed);
        }

        if (Input.GetKey(Shortcuts.moveUpCameraKey))
        {
            transform.Translate(new Vector3(0, 1, 0) * moveSpeed);
        }

        if (Input.GetKey(Shortcuts.moveDownCameraKey))
        {
            transform.Translate(new Vector3(0, -1, 0) * moveSpeed);
        }

    }
}
