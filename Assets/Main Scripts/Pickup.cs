using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Pickup : MonoBehaviour {


    public static int inventory;
    private bool pickUpAllowed;
  


    // Use this for initialization


    // Update is called once per frame
    private void Update () {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
            
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            
            pickUpAllowed = true;
        }        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {

        inventory++;
        Destroy(gameObject);
        Debug.Log(inventory);

    }

}
