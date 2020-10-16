using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

// Selectionner une liste de Block
public class Selector : MonoBehaviour
{
    // Selection : 
    // Une selection de Block 
    List<Block> selection;
    Blocks blocksScript;

    public Material selectedMaterial, defaultMaterial, startingBlockMaterial, endingBlockMaterial;

    public GameObject selectionCountTextGo;
    Text selectionCountText;

    public GameObject setStartingBlockBtnGo, setEndingBlockBtnGo;
    Button setStartingBlockBtn, setEndingBlockBtn;

    LevelIO levelIO;

    // Start is called before the first frame update
    void Start()
    {
        selection = new List<Block>();
        selectionCountText = selectionCountTextGo.GetComponent<Text>();

        setStartingBlockBtn = setStartingBlockBtnGo.GetComponent<Button>();
        setEndingBlockBtn = setEndingBlockBtnGo.GetComponent<Button>();

        levelIO = GetComponent<LevelIO>();

        // on initialise la liste
        blocksScript = GetComponent<Blocks>();
    }

    // Update is called once per frame
    void Update()
    {

        if (levelIO.isTypingLevelToSave) return;

        int x = (int)blocksScript.ActionPointPos().x;
        int y = (int)blocksScript.ActionPointPos().y;
        int z = (int)blocksScript.ActionPointPos().z;

        List<Block> blockList = blocksScript.GetBlocks();

        // Quand on clique sur le clic droit
        if (Input.GetMouseButtonDown(1))
        {

            //  on remet les materiaux par defaut de l'ancienne selection
            SetMaterialToSelection(defaultMaterial);

            // on cree une selection de blocks qui correspond a la zone de Tool

            // on flush la selection
            selection = new List<Block>(); // je recree une liste vide

            // On ajoute les cubes presents dans la zone de Tool a la selection

            

            Vector3 volume = blocksScript.GetToolScale();

            BlocksUtility
                .AddToSelectionBlocksInVolume(blockList, ref selection, x, y, z, volume);

            // On va a mettre a jour les materiaux des blocs selectionnes
            SetMaterialToSelection(selectedMaterial);

            selectionCountText.text = "SELECTION " + selection.Count;
        }

        if (Input.GetKeyDown(Shortcuts.blockBehaviourRotate))
        {
            foreach (Block selected in selection)
            {
                // Toggle block.isRotating
                selected.isRotating = !selected.isRotating;
            }
        }

        setStartingBlockBtn.interactable = blocksScript.SingleSelection();
        setEndingBlockBtn.interactable = blocksScript.SingleSelection();

        if (Input.GetKeyDown(Shortcuts.setStartingBlockKey) && blocksScript.SingleSelection())
        {
            // je recupere le block existant a cette position
            Block blockAtPos = blocksScript.GetBlockAt(new Vector3(x,y,z));

            if (blockAtPos != null)
            {
                // je recupere le game object correspondant au block
                GameObject blockGo = GameObject.Find( x + "_" + y + "_" + z);

                if (blockGo)
                {    
                    // recuperer l(e)s'ancien(s) starting block                  
                    List<Block> startingBlocks = blockList.Where(block => block.isStartingBlock).ToList();
                    startingBlocks.ForEach(action => action.isStartingBlock = false);
                    SetMaterialToBlockList(startingBlocks, defaultMaterial);

                    blockAtPos.isStartingBlock = true;
                    SetStartingBlockMat(blockGo);
                }
            }
        }

        if (Input.GetKeyDown(Shortcuts.setEndingBlockKey) && blocksScript.SingleSelection())
        {
            // je recupere le block existant a cette position
            Block blockAtPos = blocksScript.GetBlockAt(new Vector3(x, y, z));

            if (blockAtPos != null)
            {
                // je recupere le game object correspondant au block
                GameObject blockGo = GameObject.Find(x + "_" + y + "_" + z);

                if (blockGo)
                {
                    // recuperer l(e)s'ancien(s) starting block                  
                    List<Block> endingBlocks = blockList.Where(block => block.isEndingBlock).ToList();
                    endingBlocks.ForEach(action => action.isEndingBlock = false);
                    SetMaterialToBlockList(endingBlocks, defaultMaterial);

                    blockAtPos.isEndingBlock = true;
                    blockGo.GetComponent<Renderer>().material = endingBlockMaterial;
                }
            }
        }


    }

    public void SetStartingBlockMat(GameObject blockGo)
    {
        blockGo.GetComponent<Renderer>().material = startingBlockMaterial;
    }

    // methode generique pour plusieurs cas d'usage
    void SetMaterialToBlockList(List<Block> blocks, Material material)
    {
        foreach (Block block in blocks)
        {
            // reinitialiser le materiau de l'ancien starting block
            GameObject blockGo = GameObject.Find(block.x + "_" + block.y + "_" + block.z);
            Renderer startingBlockRenderer = blockGo.GetComponent<Renderer>();
            startingBlockRenderer.material = material;
        }
    }

    void SetMaterialToSelection(Material mat)
    {
        foreach (Block selected in selection)
        {
            GameObject blockGo = GameObject.Find(selected.x + "_" + selected.y + "_" + selected.z);
            if (blockGo)
            {
                Renderer mr = blockGo.GetComponent<Renderer>();
                mr.material = mat;
            }

        }
    }

}
