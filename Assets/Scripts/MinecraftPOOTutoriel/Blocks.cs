using System.Collections.Generic;
using UnityEngine;
using System.Linq;


// script permettant de gerer la liste des Block
// Il permet d ajouter, ou de supprimer des blocks et d'assigner des Behaviours ( comportement ) aux variables gameObject des Block
public class Blocks : MonoBehaviour
{
    public GameObject actionPoint;
    public GameObject tool;

    List<Block> blocks;
    public GameObject blockPrefab;

    public static Blocks instance = null;

    Game gameScript;
    Selector selector;

    void Start()
    {
        blocks = new List<Block>();
        instance = this; // utilisation de la declaration d'instance pour pouvoir appeler les methodes du script en statique

        gameScript = GetComponent<Game>();
        selector = GetComponent<Selector>();
    }

    void Update()
    {
        if(gameScript.GetCurrentGameState() != Game.GameState.LEVEL_EDITOR)
        {
            // return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            AddBlock();
        }

        if (Input.GetKeyDown(Shortcuts.removeBlocksKey))
        {
            RemoveBlock();
        }

        BlocksBehaviours();
    }

    void BlocksBehaviours()
    {
        foreach(Block block in blocks)
        {
            GameObject blockGo = block.GetGameObject();
            if (blockGo && block.isRotating)
            {
                blockGo.transform.Rotate(new Vector3(0, 1, 0));
            }
        }
    }

    // Problematique : utiliser de maniere moins verbeuse les coordonnees du point d'Action
    // on enregistre dans une variable
    // une autre fonction 
    public Vector3 ActionPointPos()
    {
        return new Vector3(actionPoint.transform.position.x, actionPoint.transform.position.y, actionPoint.transform.position.z);
    }

    void AddBlock()
    {        
        int x = (int)ActionPointPos().x;
        int y = (int)ActionPointPos().y;
        int z = (int)ActionPointPos().z;

        Vector3 scale = tool.transform.localScale;

        for(int _x = x; _x <  x + scale.x; _x++)
        {
            for (int _y = y; _y < y + scale.y; _y++)
            {
                for (int _z = z; _z < z + scale.z; _z++)
                {
                    int xAdd = _x - (int)scale.x / 2;
                    int yAdd = _y - (int)scale.y / 2;
                    int zAdd = _z - (int)scale.z / 2;

                    // Ajouter un block si il n'est pas déja présent à cette position
                    if (!BlockExists(xAdd, yAdd, zAdd))
                    {
                        blocks.Add(new Block(xAdd, yAdd, zAdd, blockPrefab));
                       
                    }       
                }
            }

        }
  
    }

    // Verifier dans la liste si les coordonnées sont déja occupés
    public bool BlockExists(int x, int y, int z)
    {
        bool exists = false;

        foreach(Block block in blocks)
        {
            int xBlock = (int)block.x;
            int yBlock = (int)block.y;
            int zBlock = (int)block.z;

            if(x == xBlock && y == yBlock && z == zBlock)
            {
                // print("Un bloc existe déja ici " + x + " " + y + " " + z);
                exists = true;
            }          
        }

        return exists;
    }

    int BlockIndex(Vector3 pos)
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            int xBlock = (int)blocks[i].x;
            int yBlock = (int)blocks[i].y;
            int zBlock = (int)blocks[i].z;

            if (pos.x == xBlock && pos.y == yBlock && pos.z == zBlock)
            {
                return i;
            }
        }

        return -1;
    } 

    /// <summary>
    /// Recuperer un block pour une position donnee si il existe
    /// </summary>
    /// <param name="pos"></param>
    /// <returns>le Block correspondant, si il existe</returns>
    public Block GetBlockAt(Vector3 pos)
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            int xBlock = (int)blocks[i].x;
            int yBlock = (int)blocks[i].y;
            int zBlock = (int)blocks[i].z;

            if (pos.x == xBlock && pos.y == yBlock && pos.z == zBlock)
            {
                return blocks[i];
            }
        }

        return null;
    }

    void RemoveBlock()
    {
        int x = (int)ActionPointPos().x;
        int y = (int)ActionPointPos().y;
        int z = (int)ActionPointPos().z;

        Vector3 scale = tool.transform.localScale;
        
        for(int _x = x; _x <  x + scale.x; _x++)
        {
            for (int _y = y; _y < y + scale.y; _y++)
            {
                for (int _z = z; _z < z + scale.z; _z++)
                {
                    int xAdd = _x - (int)scale.x / 2;
                    int yAdd = _y - (int)scale.y / 2;
                    int zAdd = _z - (int)scale.z / 2;

                    // Ajouter un block si il n'est pas déja présent à cette position
                    if (BlockExists(xAdd, yAdd, zAdd))
                    {
                        // si un bloc existe a ses coordonnees on le supprime

                        // Detruire le GameObject dans l'objet
                        GameObject blockGo = GameObject.Find(xAdd + "_" + yAdd + "_" + zAdd);

                        // Si blockGo existe on le detruit
                        if (blockGo) Destroy(blockGo);

                        Block block = GetBlockAt(new Vector3(xAdd, yAdd, zAdd));
                        blocks.Remove(block);

                    }
                }
            }

        }

    }

    /// <summary>
    /// Methode qui nous renvoie la liste des blocks instanties
    /// </summary>
    /// <returns>la liste des blocks instanties</returns>
    public List<Block> GetBlocks()
    {
        return blocks;
    }

    public void FlushBlocks()
    {
        blocks = new List<Block>();
    }

    public void AddBlockFromFile(Block block)
    {
        Block newBlock = new Block(block.x, block.y, block.z, blockPrefab);
        newBlock.isRotating = block.isRotating;
        newBlock.isStartingBlock = block.isStartingBlock;
        newBlock.isEndingBlock = block.isEndingBlock;

        blocks.Add(newBlock);

        if (newBlock.isStartingBlock)
        {
            selector.SetStartingBlockMat(newBlock.GetGameObject());
        }
    }

    public Vector3 GetToolScale()
    {
        return tool.transform.localScale;
    }

    // boolean qui renvoie Si l'outil ne s'etend que sur un seul block
    public bool SingleSelection()
    {
        return tool.transform.localScale == new Vector3(1, 1, 1); 
    }
}

public static class BlocksUtility {
    /// <summary>
    /// Ajouter a la selection les blocks presents dans le volume de Tool
    /// </summary>
    /// <param name="blocks">L'integralite des blocs instanties</param>
    /// <param name="selection">La selection qui va etre mis a jour par reference </param>
    /// <param name="x">Action point pos x</param>
    /// <param name="y">Action point pos y</param>
    /// <param name="z">Action point pos z</param>
    /// <param name="volume">Volume autour d'Action point</param>
    public static void AddToSelectionBlocksInVolume(
    List<Block> blocks,
    ref List<Block> selection,
    int x,
    int y,
    int z,
    Vector3 volume
    )
    {

        for (int _x = x; _x < x + volume.x; _x++)
        {
            for (int _y = y; _y < y + volume.y; _y++)
            {
                for (int _z = z; _z < z + volume.z; _z++)
                {
                    int posX = _x - (int)volume.x / 2;
                    int posY = _y - (int)volume.y / 2;
                    int posZ = _z - (int)volume.z / 2;

                    // si un block existe a cette position et 
                    // qu'il n'est pas deja present dans la selection
                    if (Blocks.instance.BlockExists(posX, posY, posZ) 
                        )
                    {              
                        // on l'ajoute a la selection
                        selection.Add(Blocks.instance.GetBlockAt(new Vector3(posX, posY, posZ)));
                    }

                }
            }
        }

    }
}


