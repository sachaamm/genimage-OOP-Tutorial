using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// classe correspondant a un niveau. c'est cette classe qu'on serialize pour sauver notre niveau
[Serializable]
public class BlockLevel
{
    public List<Block> blocks;
    public string test;

    public BlockLevel(string test, List<Block> blocks)
    {
        this.test = test;
        this.blocks = blocks;
    }
}
