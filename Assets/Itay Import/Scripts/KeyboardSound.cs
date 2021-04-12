using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyboardSound : MonoBehaviour
{

    public TMP_InputField inputField;

    public AudioClip[] audioClip;
    public AudioSource[] audioSource;

    public GameController controller;

    public GameObject gameObject;

    TextInput textInput;

    //public GameObject character;

    //public Transform transform;

    public Scene scene;

    [HideInInspector] public bool temp = false;

    [HideInInspector] public bool returnInput = false;

    bool isBack = false;

    [HideInInspector] public bool firstPassword = false;

    [HideInInspector] public bool secondPassword = false;

    [HideInInspector] public bool thirdPassword = false;

    //int keyboardSound = 0;

    private void Awake()
    {
        //audioSource.clip = audioClip[0];
        //audioClip = GetComponent<AudioClip[]>();
        //inputField.AddListener(playKeyboardSound);//.AddListener(playKeyboardSound);
        //controller = inputField.GetComponent<GameController>();
        textInput = controller.GetComponent<TextInput>();
    }

    void boom()
    {
        print("hello");
        //DontDestroyOnLoad(gameObject);
        //gameObject.SetActive(false);

        gameObject.tag = "Computer 6 Tag";

        /*if (controller.roomNavigation.currentRoom.roomName == "last second password")
            firstPassword = true;
        else if (controller.roomNavigation.currentRoom.roomName == "last third password")
            secondPassword = true;
        else if (controller.roomNavigation.currentRoom.roomName != "last first password")
            thirdPassword = true;*/

        SceneManager.LoadScene("Cabin_Final_01a", LoadSceneMode.Additive);
        //character.GetComponent<Transform>().SetPositionAndRotation(transform.position, character.GetComponent<Transform>().rotation);

        //GameObject character = SceneManager.GetSceneAt(1).GetRootGameObjects()[2];
        //GameObject transform = SceneManager.GetSceneAt(1).GetRootGameObjects()[9];
        //character.GetComponent<Transform>().SetPositionAndRotation(transform.transform.position, character.GetComponent<Transform>().rotation);


        /*if (firstPassword == false)
            SceneManager.LoadScene("Cabin_Final_01", LoadSceneMode.Additive);
        else if(secondPassword == false)
            SceneManager.LoadScene("Cabin_Final_01_P1C", LoadSceneMode.Additive);
        else// if(thirdPassword == false)
            SceneManager.LoadScene("Cabin_Final_01_P2C", LoadSceneMode.Additive);*/
        //else
        //SceneManager.LoadScene("Cabin_Final_01_P2C", LoadSceneMode.Additive);
        /*if (isFirst == true)
        {
            SceneManager.LoadScene("Cabin_Final_01_P1C", LoadSceneMode.Additive);
            isFirst = false;
        }
        else
        {
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Cabin_Final_01_P1C"));
            SceneManager.LoadScene("Cabin_Final_01_P1C", LoadSceneMode.Additive);
        }*/

        /*for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < controller.slowText.audioSource.Length; i++)
        {
            controller.slowText.audioSource[i].gameObject.SetActive(false);
        }*/
        //GameObject g = GameObject.FindWithTag("FinalCabinTest");
        /*for (int i = 0; i < SceneManager.GetAllScenes().Length; i++)
        {
            print(SceneManager.GetAllScenes()[i].name);
        }*/

        gameObject.SetActive(false);
        temp = false;
        returnInput = false;
        isBack = true;

        //GameObject character = SceneManager.GetSceneAt(1).GetRootGameObjects()[2];
        //GameObject transform = SceneManager.GetSceneAt(1).GetRootGameObjects()[9];
        //character.GetComponent<Transform>().SetPositionAndRotation(transform.transform.position, character.GetComponent<Transform>().rotation);

        //g.SetActive(true);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Cabin_Final_01_P1C"));
    }

    void Update()
    {
        //print(Input.)
        if (SceneManager.GetActiveScene().name == "Computer 6" && returnInput == true && temp == false)// && textInput.exitCondition == false)//Input.GetKey("escape") && temp == false)//inputField.text == "exit" && temp == false)//Input.GetKey(KeyCode.Escape) == true)
        {
            /*print("hello");
            //DontDestroyOnLoad(gameObject);
            //gameObject.SetActive(false);
            SceneManager.LoadScene("Cabin_Final_01_P1C", LoadSceneMode.Additive);
            //GameObject g = GameObject.FindWithTag("FinalCabinTest");
            //gameObject.SetActive(false);
            //g.SetActive(true);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Cabin_Final_01_P1C"));*/
            temp = true;
            boom();
        }
        else if(isBack == true)
        {
            SceneManager.UnloadScene(SceneManager.GetSceneAt(1));
            isBack = false;
        }
        /*else if(SceneManager.GetActiveScene().name.Substring(0, 8) == "Computer" && audioSource[0].gameObject.active == false)
        {
            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < controller.slowText.audioSource.Length; i++)
            {
                controller.slowText.audioSource[i].gameObject.SetActive(true);
            }
        }*/
        /*else if (SceneManager.GetActiveScene().name.Substring(0, 8) == "Computer" && controller.slowText.audioSource[0].gameObject.active == false)
        {
            for (int i = 0; i < controller.slowText.audioSource.Length; i++)
            {
                controller.slowText.audioSource[i].gameObject.SetActive(true);
            }
        }*/
        else if (Input.anyKeyDown && Input.GetMouseButtonDown(0) == false && Input.GetMouseButtonDown(1) == false && Input.GetMouseButtonDown(2) == false)// && Input.GetKey("escape") == false)
            //keyboardSound = Random.Range(0, 11);
            switch(Random.Range(0, 11))
            {
                case 0:
                    audioSource[0].clip = audioClip[0];
                    audioSource[0].Play();
                    break;
                case 1:
                    audioSource[1].clip = audioClip[1];
                    audioSource[1].Play();
                    break;
                case 2:
                    audioSource[2].clip = audioClip[2];
                    audioSource[2].Play();
                    break;
                case 3:
                    audioSource[3].clip = audioClip[3];
                    audioSource[3].Play();
                    break;
                case 4:
                    audioSource[4].clip = audioClip[4];
                    audioSource[4].Play();
                    break;
                case 5:
                    audioSource[5].clip = audioClip[5];
                    audioSource[5].Play();
                    break;
                case 6:
                    audioSource[6].clip = audioClip[6];
                    audioSource[6].Play();
                    break;
                case 7:
                    audioSource[7].clip = audioClip[7];
                    audioSource[7].Play();
                    break;
                case 8:
                    audioSource[8].clip = audioClip[8];
                    audioSource[8].Play();
                    break;
                case 9:
                    audioSource[9].clip = audioClip[9];
                    audioSource[9].Play();
                    break;
                case 10:
                    audioSource[10].clip = audioClip[10];
                    audioSource[10].Play();
                    break;
                case 11:
                    audioSource[11].clip = audioClip[11];
                    audioSource[11].Play();
                    break;
            }
        else if(Input.mouseScrollDelta.y != 0)
        {
            audioSource[12].clip = audioClip[12];
            audioSource[12].Play();
        }
    }


}
