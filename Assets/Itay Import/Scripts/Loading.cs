using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public TextMeshProUGUI[] textBoxes;

    public TMP_InputField inputField;

    public AudioClip[] audioClip;
    public AudioSource audioSource;

    public GameController controller;

    public string scene;

    //[HideInInspector] public float startingTime;

    float startingTime;

    bool timeGot = false;



    //int dot1TimeScale = 1;
    //int dot2TimeScale = 2;
    //int dot3TimeScale = 3;

    private void Awake()//Start()
    {
        controller.gameObject.SetActive(false);
        textBoxes[0].gameObject.SetActive(false);
        textBoxes[1].gameObject.SetActive(false);
        textBoxes[2].gameObject.SetActive(false);
        textBoxes[3].gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        audioSource.clip = audioClip[0];
        audioSource.Play();
    }

    private void Update()
    {
        if (textBoxes[4].gameObject.activeSelf == true && SceneManager.GetActiveScene().name == scene)// && Time.fixedTime >= 3)
        {

            if (timeGot == false)
            {
                startingTime = Time.fixedTime;
                timeGot = true;
            }

            /*if (textBoxes[1].gameObject.activeSelf == false)
            {
                Thread.Sleep(1000);
                textBoxes[1].gameObject.SetActive(true);
            }
            else if (textBoxes[2].gameObject.activeSelf == false)
            {
                Thread.Sleep(1000);
                textBoxes[2].gameObject.SetActive(true);
            }
            else if (textBoxes[3].gameObject.activeSelf == false)
            {
                Thread.Sleep(1000);
                textBoxes[3].gameObject.SetActive(true);
                Thread.Sleep(1000);

                textBoxes[0].gameObject.SetActive(true);
                inputField.gameObject.SetActive(true);

                textBoxes[1].gameObject.SetActive(false);
                textBoxes[2].gameObject.SetActive(false);
                textBoxes[3].gameObject.SetActive(false);
                textBoxes[4].gameObject.SetActive(false);
            }*/
            //Thread.Sleep(1000);
            LoadingScreen();
        }

    }

    void LoadingScreen()
    {
        if (textBoxes[1].gameObject.activeSelf == false && (Time.fixedTime >= startingTime + 4.5 && Time.fixedTime < startingTime + 6.5 || Time.fixedTime >= startingTime + 13.5))//(Time.fixedTime >= 7 && Time.fixedTime < 9 || Time.fixedTime >= 16))
        {
            //Thread.Sleep(5000);
            //print("1");
            textBoxes[1].gameObject.SetActive(true);
        }
        else if (textBoxes[2].gameObject.activeSelf == false && ((Time.fixedTime >= startingTime + 6.5 && Time.fixedTime < startingTime + 8.5) || Time.fixedTime >= startingTime + 15.5))//((Time.fixedTime >= 9 && Time.fixedTime < 11) || Time.fixedTime >= 18))
        {
            //Thread.Sleep(1000);
            //print("2");
            textBoxes[2].gameObject.SetActive(true);
        }
        else if (textBoxes[3].gameObject.activeSelf == false && ((Time.fixedTime >= startingTime + 8.5 && Time.fixedTime < startingTime + 10.5) || Time.fixedTime >= startingTime + 17.5))//((Time.fixedTime >= 11 && Time.fixedTime < 13) || Time.fixedTime >= 20))
        {
            //Thread.Sleep(1000);
            //print("3");
            textBoxes[3].gameObject.SetActive(true);
            //Thread.Sleep(1000);
        }
        else if (Time.fixedTime > startingTime + 10.5 && Time.fixedTime < startingTime + 11.5)//(Time.fixedTime > 13 && Time.fixedTime < 14)
        {
            textBoxes[1].gameObject.SetActive(false);
            textBoxes[2].gameObject.SetActive(false);
            textBoxes[3].gameObject.SetActive(false);
        }
        else if(textBoxes[3].gameObject.activeSelf == true && Time.fixedTime > startingTime + 19.5)//Time.fixedTime > 22)
        {

            textBoxes[0].gameObject.SetActive(true);
            inputField.gameObject.SetActive(true);
            controller.gameObject.SetActive(true);

            textBoxes[1].gameObject.SetActive(false);
            textBoxes[2].gameObject.SetActive(false);
            textBoxes[3].gameObject.SetActive(false);
            textBoxes[4].gameObject.SetActive(false);
            audioSource.clip = audioClip[1];
            audioSource.PlayOneShot(audioSource.clip, 0.3f);
        }
    }
}




