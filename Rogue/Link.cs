using UnityEngine;
using System.Collections;


public enum Position
{
    LEFT,
    RIGHT,
    TOP,
    BOT
};

public class Link : MonoBehaviour
{

    bool is_Linked;
    Link _Linked_to;
    //Standard _From;
    Position position;

    public Link(/*Standard from, */Position type, Link linked_to = null)
    {
        //this._From = from;
        this.position = type;
        this._Linked_to = linked_to;
        this.is_Linked = (linked_to == null) ? false : true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            int movex, movey;
            switch (position)
            {
                case Position.LEFT:
                    movex = -1;
                    movey = 0;
                    break;

                case Position.RIGHT:
                    movex = 1;
                    movey = 0;
                    break;

                case Position.TOP:
                    movex = 0;
                    movey = 1;
                    break;

                case Position.BOT:
                    movex = 0;
                    movey = 1;
                    break;

                default:
                    movex = 0;
                    movey = 0;
                    break;
            }


            //GameObject.Find("Main Camera").transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x + x, GameObject.Find("Main Camera").transform.position.y + y, -10);
            //GameObject.Find("Player").transform.position = new Vector2(GameObject.Find("Player").transform.position.x + playx, GameObject.Find("Player").transform.position.y + playy);

        }
    }

}
