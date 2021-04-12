using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject ChestClose;
    public GameObject ChestOpener;
    public GameObject item;
    public Vector3 Vector;
    private bool pickedup = false;
    private bool canOpen = true;
    public AudioSource audioSrc;
    

    void Start()
    {
        ChestClose.SetActive(true);
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character") || collision.gameObject.name.Equals("ForestCharacter"))
        {

            if (canOpen)
            {
                audioSrc.Play();
                ChestClose.SetActive(false);
                ChestOpener.SetActive(true);


                if (!pickedup)
                {

                    Instantiate(item, Vector, transform.rotation);

                }

                pickedup = true;

            }
        }
        
   
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character") || collision.gameObject.name.Equals("ForestCharacter"))
        {

            ChestOpener.SetActive(true);
            ChestClose.SetActive(false);

            canOpen = false;
        }
       
      
    }
}

