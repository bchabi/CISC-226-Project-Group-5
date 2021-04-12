using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    public Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    public Transform homePos;
    public AudioSource audioSrc;
    public AudioSource audioSrc2;
    public GameObject player;
    public Transform North;
    
    private bool canGoHome;
    void Start()
    {
        myAnim = GetComponent<Animator>();
        


    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange && player.activeSelf)
        {
            canGoHome = false;
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            canGoHome = false;
            GoHome();
        }
        else if (!player.activeSelf)
        {

            
            if (Vector3.Distance(transform.position, North.position) != 0 && !canGoHome)
            {
                myAnim.SetBool("isMoving", true);
                myAnim.SetFloat("moveX", (-North.position.x + transform.position.x));
                myAnim.SetFloat("moveY", (North.position.y - transform.position.y));
                transform.position = Vector3.MoveTowards(transform.position, North.transform.position, speed * Time.deltaTime);

            }
            else
            {
                canGoHome = true;
                GoHome();
            }

        }


        if (myAnim.GetBool("isMoving") && (Vector3.Distance(target.position, transform.position) > 4 || Vector3.Distance(target.position, North.position) > 4))
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc2.Stop();
                audioSrc.Play();


            }

        }

        else if (myAnim.GetBool("isMoving") && (Vector3.Distance(target.position, transform.position) <= 4 || Vector3.Distance(target.position, North.position) <= 4))
        {
            if (!audioSrc2.isPlaying)
            {
                audioSrc.Stop();
                audioSrc2.Play();


            }
        }

        else
        {
            // Always stop the audio if the player is not inputting movement.
            audioSrc.Stop();
            audioSrc2.Stop();

        }

    }

    public void FollowPlayer()
    {
        
        myAnim.SetBool("isMoving", true);
        
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        
        myAnim.SetFloat("moveX", (-homePos.position.x + transform.position.x));
        myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, (speed + 2) * Time.deltaTime);
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
            
        }
    }

}
