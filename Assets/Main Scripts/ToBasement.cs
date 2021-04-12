using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBasement : MonoBehaviour
{
    public Transform basementSpawn;
    public Transform characterPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character") || collision.gameObject.name.Equals("ForestCharacter"))
        {

            characterPosition.position = basementSpawn.position;
        }
    }
}
