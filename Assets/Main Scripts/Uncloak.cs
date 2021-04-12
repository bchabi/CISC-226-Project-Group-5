using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncloak : MonoBehaviour
{
    public Transform target;
    public GameObject uncloakedVersion;
    public CloakDurability cloakd;
    

    void Start()
    {
        
        gameObject.SetActive(false);
    }



    void Update()
    {

        gameObject.transform.position = target.position;

        if (Input.GetKeyDown("space"))
        {
            
            uncloakedVersion.SetActive(true);
            cloakd.canCountdown = true;

            gameObject.SetActive(false);

            
            
            
        }
    }
}
