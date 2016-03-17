using UnityEngine;
using System.Collections;

public class Legs : MonoBehaviour {


    public Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Plateform")
        {
            GameObject.Find("Player").GetComponent<Move>().grounded = true;
        }
    }
}
