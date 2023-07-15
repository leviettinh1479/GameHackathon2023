using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    

    private Rigidbody2D rigidbody2D;
    private Animator ani;
    private SpriteRenderer spriteRenderer;
    private float dirX = 0f;
    [SerializeField]
    private float movespeed = 7f;
    [SerializeField]
    public bool nendat;
    private float jumpF = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       

        //particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(dirX * movespeed, rigidbody2D.velocity.y);
        //material.SetFloat("_Fade", 0.1f);
        if (Input.GetButtonDown("Jump"))
        {
            ani.SetBool("IsJumping", true);


            if (nendat == true)
            { 
             
            
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpF);

                nendat = false;
                

            }
            
           
        }
        else
        {
            ani.SetBool("IsJumping", false);

        }



        UpdateAni();
    }
    private void UpdateAni()
    {
        if (dirX > 0f)
        {    
          
            ani.SetBool("IsRunning", true);
            spriteRenderer.flipX = false;
       
        }
        else if (dirX < 0f)
        {
        
            ani.SetBool("IsRunning", true);
            spriteRenderer.flipX = true;
            


        }
        else
        {
            ani.SetBool("IsRunning", false);


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nendat")
        {

            nendat = true;
        }



    }

}

