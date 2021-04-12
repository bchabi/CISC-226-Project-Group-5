using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private Animator myAnim;
    public GameOverScreen GameOverScreen;
    

    void Start()
    {
        myAnim = GetComponent<Animator>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (-moveSpots[randomSpot].position.x + transform.position.x));
        myAnim.SetFloat("moveY", (moveSpots[randomSpot].position.y - transform.position.y));
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            GameOverScreen.Setup();
            //If the GameObject has the same tag as specified, output this message in the console

        }
    }
}
