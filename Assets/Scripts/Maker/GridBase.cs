using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridBase : MonoBehaviour
{

    public GameObject nodePrefab;

    public int sizeX;
    public int sizeY;
    public int offset = 1;

    public Node[,] grid;

    private static GridBase instance = null;

    public static GridBase GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
        CreateGrid();
        CreateMouseCollision();
    }

    void CreateGrid()
    {
        grid = new Node[sizeX, sizeY];

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                float posX = x * offset;
                float posY = y * offset;

                GameObject go = Instantiate(nodePrefab, new Vector2(posX,  posY), Quaternion.identity) as GameObject;
                go.transform.parent = transform.GetChild(1).transform;

                NodeObject nodeObj = go.GetComponent<NodeObject>();
                nodeObj.posX = x;
                nodeObj.posY = y;

                Node node = new Node();
                node.vis = go;
                node.tileRenderer = node.vis.GetComponentInChildren<MeshRenderer>();
                node.isWalkable = true;
                node.nodePosX = x;
                node.nodePosY = y;
                grid[x, y] = node;
            }
        }
    }

    void CreateMouseCollision()
    {
        GameObject go = new GameObject("room");
        go.AddComponent<BoxCollider>();
        go.GetComponent<BoxCollider>().size = new Vector2(sizeX * offset, sizeY * offset);
        go.transform.position = new Vector2((sizeX * offset) / 2 - 1,  (sizeY * offset) / 2 - 1);
    }

    public Node NodeFromWorldPosition(Vector2 worldPosition)
    {
        float worldX = worldPosition.x;
        float worldY = worldPosition.y;

        worldX /= offset;
        worldY /= offset;

        int x = Mathf.RoundToInt(worldX);
        int y = Mathf.RoundToInt(worldY);

        if (x > sizeX)
            x = sizeX;
        if (y > sizeY)
            y = sizeY;
        if (x < 0)
            x = 0;
        if (y < 0)
            y = 0;

        return grid[x, y];

    }
        
}
