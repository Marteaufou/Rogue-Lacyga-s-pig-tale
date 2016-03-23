using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    //This will be our maximum speed as we will always be multiplying by 1
    public float maxSpeed = 2f;
    public float JumpSpeed = 10f;
    //a boolean value to represent whether we are facing left or not 
    bool facingLeft = true;

    //to check ground and to have a jumpforce we can change in the editor
    public bool grounded = false;
    public float Saut = 0;
    public int jumptimer;
    int i = 0;

    public float move;
    public float jump;

    public int Shot = -1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D rigidbody2D = this.GetComponent<Rigidbody2D>();
        move = Input.GetAxis("Horizontal");//Gives us of one if we are moving via the arrow keys
                                           //move our Players rigidbody

        jump = Input.GetAxis("Jump");//Si on appuie sur espace
        bool shoot = Input.GetButtonDown("Fire1");




        //set our spee
        //if we are moving left but not facing left flip, and vice versa
        if (move < 0 && !facingLeft)
        {

            Flip();
        }
        else if (move > 0 && facingLeft)
        {
            Flip();
        }


         if (jump != 0 && grounded)
         {
            rigidbody2D.AddForce(new Vector2(0, 1000), new ForceMode2D());
            grounded = false;
         }
         if (Saut > 0)
         {
             i++;
             if (i == jumptimer)
             {
                 Saut = 0;
                 i = 0;
             }

         }
         
       /* if (Input.GetKeyDown("space"))
        {
            rigidbody2D.AddForce(new Vector2(0, 1000), new ForceMode2D());
        }*/
        rigidbody2D.velocity = new Vector3(move * maxSpeed, rigidbody2D.velocity.y);






        if (shoot)
        {
            WeaponScript weapon = GameObject.Find("weapon").GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false);
            }
        }



    }


    //flip if needed
    void Flip()
    {

        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        Shot *= -1;
        transform.localScale = theScale;
    }
}
