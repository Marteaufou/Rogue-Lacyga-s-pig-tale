using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ROGUE : MonoBehaviour
{
    Assets.Scripts.Rogue.Map map;
    public List<GameObject> rooms;
    Random rand;
    // Use this for initialization
    public ROGUE()
    {
        

        
    }

    void Awake()
    {

        string path = @"Assets/Prefab/Rooms/Resources";

        int nbrFichiers = Directory.GetFiles(path).Length / 2;

        GameObject room;

        /*for (int i = 0; i < nbrFichiers; i++)
        {
            string name = "room_" + i.ToString();
            room = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;

            rooms.Add(room);
        }*/
        map = new Assets.Scripts.Rogue.Map(5, 5, 0, 2, 4, 2);
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                string name = "room_" + Random.Range(0, nbrFichiers);
                room = Instantiate(Resources.Load(name, typeof(GameObject)), new Vector2(24 + i * 24,12 + j * 12),Quaternion.identity ) as GameObject;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    Room[,] make()
    {
        Room[,] Map = new Room[5, 5];
        List<GameObject> rooms = new List<GameObject>();

        string path = "Assets/Resources"; //Prefab/Rooms";

        int nbrFichiers = Directory.GetFiles(path).Length / 2;

        GameObject room = new GameObject();

        for (int i = 0; i < nbrFichiers; i++)
        {
            room = Instantiate(Resources.Load("room_" + i.ToString(), typeof(GameObject))) as GameObject;
            
            rooms.Add(room);
        }

        return Map;
    }

    #region Generation


    #endregion
}
