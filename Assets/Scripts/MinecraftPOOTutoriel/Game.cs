using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using System;
using System.Linq;

// script general du jeu : permet de gerer les differentes phases de jeu
public class Game : MonoBehaviour
{
    public enum GameState
    {
        LEVEL_EDITOR, // 0 : creer des blocks 
        IN_GAME // 1 : on fait spawner le personnage et on joue
    }

    public GameObject thirdPersonControllerPrefab;

    GameState gameState = GameState.LEVEL_EDITOR;

    Blocks blocksScript;

    GameObject player;
    Rigidbody playerRg;

    private void Start()
    {
        blocksScript = GetComponent<Blocks>();
    }

    private void Update()
    {
        // Quand on appuie sur la touche Toggle Game Mode
        // on change le mode de jeu

        if (Input.GetKeyDown(Shortcuts.toggleGameStateKey))
        {
            // convertir une enum en int
            int gameStateIndex = (int)gameState;
            gameStateIndex++;

            gameStateIndex %= Enum.GetNames(typeof(GameState)).Length;
            // convertir un int en enum
            gameState = (GameState)gameStateIndex;

            switch (gameState)
            {
                case GameState.LEVEL_EDITOR:

                    break;

                case GameState.IN_GAME:
                    LaunchGame();
                    break;
            }
        }

        if (Input.GetKeyDown(Shortcuts.respawnPlayerKey))
        {
            SetPlayerPosToStartingBlock();
        }


    }

    void LaunchGame()
    {
        // instantier le third person controller 
        player = Instantiate(thirdPersonControllerPrefab);
        player.name = "ThirdPersonController";
        playerRg = player.GetComponent<Rigidbody>();

        SetPlayerPosToStartingBlock();
    }

    void SetPlayerPosToStartingBlock()
    {
        // on annule les forces qui s'appliquent sur le player
        playerRg.velocity = new Vector3();

        // placer le third person controller sur le starting block

        // on recupere tous les blocks
        List<Block> blockList = blocksScript.GetBlocks();

        Vector3 startingBlockPos = new Vector3();
        // on recupere le startingBlock parmi les blocks
        foreach (Block block in blockList)
        {
            if (block.isStartingBlock)
            {
                startingBlockPos = new Vector3(block.x, block.y, block.z);
                player.transform.rotation = block.GetGameObject().transform.rotation;
            }
        }

        player.transform.position = startingBlockPos + new Vector3(0, 1, 0);

        GameObject builder = GameObject.Find("Builder");

        GameObject cameraMain = builder.GetComponentInChildren<Camera>().gameObject;

        GameObject actionPoint = GameObject.Find("ActionPoint").gameObject;

        // position de la camera sur le joueur
        cameraMain.transform.position = player.transform.position;

        // rotation de la camera soit la meme que celle du joueur
        cameraMain.transform.rotation = player.transform.rotation;

        // on va reculer la camera legerement pour la place derriere le joueur
        cameraMain.transform.Translate(
            - player.transform.forward * 5 + transform.up * 3);

        cameraMain.transform.LookAt(player.transform);

        actionPoint.transform.parent = null;

        // on enfante la camera dans le joueur
        builder.transform.parent = player.transform;
    }

    public GameState GetCurrentGameState()
    {
        return gameState;
    }


}
