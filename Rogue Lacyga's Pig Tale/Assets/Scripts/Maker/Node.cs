using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node {

    public int nodePosX;
    public int nodePosY;
    public GameObject vis;
    public MeshRenderer tileRenderer;
    public bool isWalkable;
    public LevelEditor.Level_Object placeObj;
    public List<LevelEditor.Level_Object> stackdObjs = new List<LevelEditor.Level_Object>();
    //public LevelEditor.Level_WallObj wallObj;
}
