using UnityEngine;
using System.Collections;

namespace LevelEditor
{
    public class Level_Object : MonoBehaviour
    {

        public string obj_Id;
        public int gridPosX;
        public int gridPosY;
        public GameObject modelVisualization;
        public Vector2 worldPositionOffset;
        public Vector2 worldRotation;

        public bool isStackableObj = false;
        public bool isWallObject = false;
        public float rotateDegrees = 90;

        public void UpdateNode(Node[,] grid)
        {
            Node node = grid[gridPosX, gridPosY];

            Vector2 worldPosition = node.vis.transform.position;
            worldPosition += worldPositionOffset;
            transform.rotation = Quaternion.Euler(worldRotation);
            transform.position = worldPosition;
        }

        public void ChangeRotation()
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles += new Vector3( 0,0,rotateDegrees);
            transform.localRotation = Quaternion.Euler(eulerAngles);
        }

        public SaveableLevelObject GetSaveableObject()
        {
            SaveableLevelObject savedObj = new SaveableLevelObject();
            savedObj.obj_Id = obj_Id;
            savedObj.posX = gridPosX;
            savedObj.posY = gridPosY;

            worldRotation = transform.localEulerAngles;

            savedObj.rotX = worldRotation.x;
            savedObj.rotY = worldRotation.y;
            savedObj.isWallObject = isWallObject;
            savedObj.isStackable = isStackableObj;

            return savedObj;
        }

    }

    [System.Serializable]
    public class SaveableLevelObject
    {
        public string obj_Id;
        public int posX;
        public int posY;

        public float rotX;
        public float rotY;
        public float rotZ;

        public bool isWallObject = false;
        public bool isStackable = false;
    }
}