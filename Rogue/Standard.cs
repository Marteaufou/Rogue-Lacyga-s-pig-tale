using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Standard : MonoBehaviour {
    //Créé un type "standard" pour gérer le rogue

    Room _Room;
    List<Link> _Walls;
    int x, y;

    public Standard(Room Room, int x, int y, List<Link> Walls)
    {
        this._Room = Room;
        this.x = x;
        this.y = y;
        this._Walls = Walls;
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
