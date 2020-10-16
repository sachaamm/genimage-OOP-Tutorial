using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

using UnityEditor;

// script permettant de sauver un niveau ou de charger un niveau
public class LevelIO : MonoBehaviour
{
    Blocks blocksScript;
    string levelsFolder = "Levels";

    public bool isTypingLevelToSave = false;

    public GameObject inputFieldGo;
    InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        blocksScript = GetComponent<Blocks>();
        inputField = inputFieldGo.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        isTypingLevelToSave = inputField.isFocused;

        string levelToSaveName = inputField.text;

        if (Input.GetKeyDown(Shortcuts.saveLevelKey))
        {
            // je serialize ma liste de blocks

            BlockLevel blockLevel = new BlockLevel(" titi ", blocksScript.GetBlocks());
            // blockLevel.blocks = blocksScript.GetBlocks(); // je lui attribue la liste existante

            Debug.Log(blocksScript.GetBlocks().Count);

            string json = JsonUtility.ToJson(blockLevel);

            Debug.Log(json);

            System.IO.File.WriteAllText(
                Application.dataPath + "/" + levelsFolder + "/" + levelToSaveName + ".json" , json);

        }

        if (Input.GetKeyDown(Shortcuts.loadLevelKey))
        {

            string path = EditorUtility.OpenFilePanel("Select level json", "", "json");
            if (path.Length != 0)
            {
                blocksScript.FlushBlocks();

                var json = System.IO.File.ReadAllText(path);

                BlockLevel blockLevel = JsonUtility.FromJson<BlockLevel>(json);
                Debug.Log(blockLevel.blocks.Count);

                foreach (Block block in blockLevel.blocks)
                {
                    blocksScript.AddBlockFromFile(block);

                }
            }

        }
    }
}
