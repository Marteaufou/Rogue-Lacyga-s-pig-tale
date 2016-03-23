using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D rigidbody2D = this.GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown("space"))
        {
            rigidbody2D.AddForce(new Vector2 (0, 100f),new ForceMode2D());
        }
    }
}
