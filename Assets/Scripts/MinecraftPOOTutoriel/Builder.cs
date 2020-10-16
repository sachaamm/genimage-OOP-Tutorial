using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script permettant de Changer la taille de tool et mettre a jour sa position
public class Builder : MonoBehaviour
{
    public GameObject builderTool;
    public GameObject actionPoint;
    Vector3 scale;

    int scaleIncrement = 1;

    Game gameScript;
    LevelIO levelIO;

    void Start()
    {
        gameScript = GetComponent<Game>();
        levelIO = GetComponent<LevelIO>();
    }

    void Update()
    {

        if (levelIO.isTypingLevelToSave) return;
       
        if(gameScript.GetCurrentGameState() != Game.GameState.LEVEL_EDITOR)
        {
            // return; // on bloque la fonction et on s'arrete ici           
        }

        scale = builderTool.transform.localScale;

        UpdateToolPos();
  
        // Scaler le cube sur x, y, et/ou z
        if (Input.GetKeyDown(Shortcuts.builderToolScaleXupKey))
        {
            // augmenter le scale x de builderTool de 1
            scale.x += scaleIncrement;
        }

        if (Input.GetKeyDown(Shortcuts.builderToolScaleXdownKey))
        {
            // reduire le scale x de builderTool de 1 si il est > 1
            if (scale.x > 1) scale.x -= scaleIncrement;
        }

        if (Input.GetKeyDown(Shortcuts.builderToolScaleYupKey))
        {
            // augmenter le scale y de builderTool de 1
            scale.y += scaleIncrement;
        }

        if (Input.GetKeyDown(Shortcuts.builderToolScaleYdownKey))
        {
            // reduire le scale y de builderTool de 1 si il est > 1
            if (scale.y > 1) scale.y -= scaleIncrement;
        }

        if (Input.GetKeyDown(Shortcuts.builderToolScaleZupKey))
        {
            // augmenter le scale z de builderTool de 1
            scale.z += scaleIncrement;
        }

        if (Input.GetKeyDown(Shortcuts.builderToolScaleZdownKey))
        {
            // reduire le scale z de builderTool de 1 si il est > 1
            if (scale.z > 1) scale.z -= scaleIncrement;
        }

        if (Input.GetKeyDown(Shortcuts.builderToolScaleGlobalupKey))
        {
            // augmenter le scale global de builderTool de 1         
            scale.x += scaleIncrement;
            scale.y += scaleIncrement;
            scale.z += scaleIncrement;
        }

        if (Input.GetKeyDown(Shortcuts.builderToolScaleGlobaldownKey))
        {
            // reduire le scale global de builderTool de 1 si il est > 1
            if (scale.x > scaleIncrement) scale.x -= scaleIncrement;
            if (scale.y > scaleIncrement) scale.y -= scaleIncrement;
            if (scale.z > scaleIncrement) scale.z -= scaleIncrement;
        }

        builderTool.transform.localScale = scale;
    }

    void UpdateToolPos()
    {
        // Probleme de resolution sur les chiffres pairs
        float oddXOffset = scale.x % 2 == 0 ? 0.5f : 0;
        float oddYOffset = scale.y % 2 == 0 ? 0.5f : 0;
        float oddZOffset = scale.z % 2 == 0 ? 0.5f : 0;

        builderTool.transform.position = new Vector3(
            (int)actionPoint.transform.position.x - oddXOffset,
            (int)actionPoint.transform.position.y - oddYOffset, 
            (int)actionPoint.transform.position.z - oddZOffset);
    }
}
