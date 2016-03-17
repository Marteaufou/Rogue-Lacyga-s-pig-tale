using UnityEngine;
using System.Collections;

public class Borders : MonoBehaviour {

    public float x;
    public float y;
    public float playx;
    public float playy;
   
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x + x, GameObject.Find("Main Camera").transform.position.y + y,-10);
            GameObject.Find("Player").transform.position = new Vector2(GameObject.Find("Player").transform.position.x + playx, GameObject.Find("Player").transform.position.y + playy);

        }
    }
}
