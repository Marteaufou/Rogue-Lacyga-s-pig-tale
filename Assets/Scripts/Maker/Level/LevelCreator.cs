using UnityEngine;
using System.Collections;
using System.IO;

namespace LevelEditor
{
    public class LevelCreator : MonoBehaviour
    {

        LevelManager manager;
        GridBase gridBase;
        InterfaceManager ui;

        //Place obj variables
        bool hasObj;
        GameObject objToPlace;
        GameObject cloneObj;
        Level_Object objProperties;
        Vector2 mousePosition;
        Vector2 worldPosition;
        bool deleteObj;

        //paint tile variables
        bool hasMaterial;
        bool paintTile;
        public Material matToPlace;
        Node previousNode;
        Material prevMaterial;
        Quaternion targetRot;

        //place stack objs variables
        bool placesStackObj;
        GameObject stackObjToPlace;
        GameObject stackCloneObj;
        Level_Object stackObjPropertied;
        bool deleteStackObj;

        //Wallcreator variables
        bool createWall;
        public GameObject wallPrefab;
        Node startNode_Wall;
        Node endNodeWall;
        public Material[] wallPlacementMat;
        bool deleteWall;

        void Start()
        {
            gridBase = GridBase.GetInstance();
            manager = LevelManager.GetInstance();
            ui = InterfaceManager.GetInstance();

            //PaintAll();
        }

        void Update()
        {
            PlaceObject();
            // PaintTile();
            DeleteObjs();
            /*PlaceStackdObj();
            CreateWall();
            DeleteStackedObjs();
            DeleteWallsActual();*/

        }

        void UpdateMousePosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                mousePosition = hit.point;
            }
        }

        #region Place Objects
        void PlaceObject()
        {
            if (hasObj)
            {
                UpdateMousePosition();

                Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

                worldPosition = curNode.vis.transform.position;

                if (cloneObj == null)
                {
                    cloneObj = Instantiate(objToPlace, worldPosition, Quaternion.identity) as GameObject;
                    objProperties = cloneObj.GetComponent<Level_Object>();
                }
                else
                {
                    cloneObj.transform.position = worldPosition;

                    if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
                    {
                        if (curNode.placeObj != null)
                        {
                            manager.inSceneGameObjects.Remove(curNode.placeObj.gameObject);
                            Destroy(curNode.placeObj.gameObject);
                            curNode.placeObj = null;
                        }

                        GameObject actualObjPlaced = Instantiate(objToPlace, worldPosition, cloneObj.transform.rotation) as GameObject;
                        actualObjPlaced.transform.parent = GameObject.Find("room").transform;
                        Level_Object placedObjProperties = actualObjPlaced.GetComponent<Level_Object>();


                        curNode.placeObj = placedObjProperties;
                        placedObjProperties.gridPosX = curNode.nodePosX;
                        placedObjProperties.gridPosY = curNode.nodePosY;


                        manager.inSceneGameObjects.Add(actualObjPlaced);



                    }

                    if (Input.GetMouseButton(1))
                    {
                        objProperties.ChangeRotation();
                    }
                }
            }

            else
            {
                if (cloneObj != null)
                {
                    Destroy(cloneObj);
                }
            }
        }

        public void PassGameObjectToPlace(string objId)
        {
            if (cloneObj != null)
            {
                Destroy(cloneObj);
            }

            CloseAll();
            hasObj = true;
            cloneObj = null;
            objToPlace = RessourcesManager.GetInstance().GetObjBase(objId).objPrefab;
        }

        void DeleteObjs()
        {
            if (deleteObj)
            {
                UpdateMousePosition();

                Node curNode = gridBase.NodeFromWorldPosition(mousePosition);

                if (Input.GetMouseButton(0) && !ui.mouseOverUIElement)
                {
                    if (curNode.placeObj != null)
                    {
                        if (manager.inSceneGameObjects.Contains(curNode.placeObj.gameObject))
                        {
                            manager.inSceneGameObjects.Remove(curNode.placeObj.gameObject);
                            Destroy(curNode.placeObj.gameObject);
                        }

                        curNode.placeObj = null;
                    }
                }
            }
        }

        public void DeleteObj()
        {
            CloseAll();
            deleteObj = true;
        }

        public void Save()
        {
            string path = @"Assets/Prefab/Rooms";

            int nbrFichiers = Directory.GetFiles(path).Length / 2;

            UnityEditor.PrefabUtility.CreatePrefab(@"Assets/Prefab/Rooms/room_" +nbrFichiers.ToString() + ".prefab", GameObject.Find("room"));
        }
        #endregion

        #region Tile Painting
        #endregion

        #region Stacked Objects;
        #endregion

        #region Wall Creator
        #endregion

        void CloseAll()
        {
            hasObj = false;
            deleteObj = false;
            paintTile = false;
            placesStackObj = false;
            createWall = false;
            hasMaterial = false;
            deleteStackObj = false;
            deleteWall = false;
        }
    }
}
