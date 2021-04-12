using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator anim;

    Vector2 movement;

    public AudioSource audioSrc;

    public bool canCloak;

    public GameObject cloakedVersion;

    public GameOverScreen GameOverScreen;

    public CloakDurability cloakd;





    // Update is called once per frame
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        // If the user is pressing any of the move buttons:
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else
        {
            // Always stop the audio if the player is not inputting movement.
            audioSrc.Stop();
        }

        if (Input.GetKey("space") && !cloakedVersion.activeInHierarchy)
        {
            Debug.Log("pressed space");
            if(cloakd.timerSlider.value == 3)
            {
                Cloaked();
            }
            

        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Cloaked()
    {
        if (canCloak)
        {

            
            gameObject.SetActive(false);
           
            cloakedVersion.SetActive(true);

            



        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Enemy")
        {
            GameOverScreen.Setup();
            //If the GameObject has the same tag as specified, output this message in the console
            
        }
    }
}
