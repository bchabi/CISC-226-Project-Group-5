using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audiosrc;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.Equals("Character"))
        {
            if (!audiosrc.isPlaying)
            {
                audiosrc.Play();
            }
            else
            {
                audiosrc.UnPause();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Character"))
        {
            audiosrc.Pause();
        }
    }
}
