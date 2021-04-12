using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerScreenUnstable : MonoBehaviour
{
    public TMP_InputField inputField;

    public GameController controller;

    public AudioClip audioClip;

    public AudioSource[] audioSource;

    [HideInInspector] public float startingTime;

    //[HideInInspector] public Random random;

    //int flashingTextTimeScale = 0;

    private void Awake()
    {
        audioSource[1].gameObject.SetActive(false);
    }

    /*private void Start()
    {
        startingTime = Time.fixedTime;
    }*/

    void Update()
    {
        //print(startingTime);
        //if(Time.fixedTime >= 24.65 && Time.fixedTime <= 25)
        if (Time.fixedTime >= startingTime + 2 && Time.fixedTime <= startingTime + 2.35)
        {
            audioSource[1].gameObject.SetActive(true);
        }

        //if (Time.fixedTime >= 25 && Time.fixedTime <= 25.5)
        if (Time.fixedTime >= startingTime + 2.35 && Time.fixedTime <= startingTime + 2.45)
        {
            audioSource[0].Pause();
            //audioSource[1].gameObject.SetActive(true);
            //audioSource[1].clip = audioClip;
            //audioSource[1].Play();
            //print("1");
            inputField.gameObject.SetActive(false);
            controller.displayText.gameObject.SetActive(false);
            controller.gameObject.SetActive(false);
        }

        /*if (Time.fixedTime >= 35 && Time.fixedTime <= 35.25)
        {
            inputField.gameObject.SetActive(true);
            controller.displayText.gameObject.SetActive(true);
            controller.gameObject.SetActive(true);
        }

        if (Time.fixedTime >= 35.27 && Time.fixedTime <= 35.75)
        {
            inputField.gameObject.SetActive(false);
            controller.displayText.gameObject.SetActive(false);
            controller.gameObject.SetActive(false);
        }*/

        /*if (Time.fixedTime >= 37.5 && Time.fixedTime <= 38.5)
        {
            inputField.gameObject.SetActive(true);
            controller.displayText.gameObject.SetActive(true);
            controller.gameObject.SetActive(true);
            //inputField.gameObject.SetActive(false);
            //controller.displayText.gameObject.SetActive(false);
            //controller.gameObject.SetActive(false);
            audioSource[0].Play();
            //flashingTextTimeScale += 1;
        }*/

        /*if (Time.fixedTime >= 37.5 + 0.2 * flashingTextTimeScale && Time.fixedTime <= 37.75 + 0.2 * flashingTextTimeScale && flashingTextTimeScale % 2 == 1)
        {
            //inputField.gameObject.SetActive(true);
            //controller.displayText.gameObject.SetActive(true);
            //controller.gameObject.SetActive(true);
            inputField.gameObject.SetActive(false);
            controller.displayText.gameObject.SetActive(false);
            controller.gameObject.SetActive(false);
            if (flashingTextTimeScale != 5)
                flashingTextTimeScale += 1;
            //audioSource[0].Play();
        }*/

        //if (Time.fixedTime >= 38.5 && Time.fixedTime <= 39)
        if (Time.fixedTime >= startingTime + 12.85 && Time.fixedTime <= startingTime + 13.45)
        {
            inputField.gameObject.SetActive(true);
            controller.displayText.gameObject.SetActive(true);
            controller.gameObject.SetActive(true);
            audioSource[1].gameObject.SetActive(false);
            audioSource[0].Play();
            //print("2");
        }

        if (Time.fixedTime > startingTime + 14.35)
        {
            audioSource[0].Stop();
            //audioSource[0].PlayOneShot(audioSource[0].clip, 0.3f);
            audioSource[0].GetComponent<ComputerScreenUnstable>().enabled = false;
            //print("3");
        }

    }
}
