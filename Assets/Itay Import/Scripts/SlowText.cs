using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlowText : MonoBehaviour
{

    public GameController controller;

    public TMP_InputField inputField;

    public AudioSource[] audioSource;

    TextMovement textMovement;

    [HideInInspector] public string stringToPrint = "";

    [HideInInspector] public float numberOfLines;

    [HideInInspector] public float timeOfPrevious;

    [HideInInspector] public bool isFirst = true;

    [HideInInspector] public bool isGoodInput = false;

    double speed = 0.01;

    public void Awake()
    {
        textMovement = controller.displayText.GetComponent<TextMovement>();
    }

    public void startSlow(string input)
    {
        timeOfPrevious = Time.fixedTime;
        stringToPrint = input;
        numberOfLines = stringToPrint.Split('\n').Length;
        //print("String: " + stringToPrint);
        inputField.gameObject.SetActive(false);
        if (controller.roomNavigation.currentRoom.roomName == "simple commands")
            speed = 0.001;

    }

    public void Update()
    {
        //print("String: " + stringToPrint);
        if (stringToPrint.Length > 0 && Time.fixedTime > timeOfPrevious + speed)//0.01)
        {
            //print(Time.deltaTime);
            //print(speed);
            //print("Length: " + stringToPrint.Length);
            //print("String: " + stringToPrint);
            //print("Is first: " + isFirst);
            controller.actionLog.Add(stringToPrint.Substring(0, 1));
            stringToPrint = stringToPrint.Substring(1, stringToPrint.Length - 1);
            timeOfPrevious = Time.fixedTime;
            //if(controller.displayText.gameObject.active == true)
            //print(stringToPrint.Substring(0, 1));
            controller.DisplayLoggedText(true, isFirst);
            textMovement.ChangeYLocation();
            isFirst = false;
            if (audioSource[0].isPlaying == false && audioSource[1].isPlaying == false && audioSource[2].isPlaying == false)
            {
                int temp = Random.Range(0, 2);
                audioSource[temp].PlayOneShot(audioSource[temp].clip, 0.25f);
            }
        }
        else if (stringToPrint.Length == 0 && inputField.gameObject.active == false)
        {
            //if(numberOfLines*controller.textMovement.fontSize + controller.scrolling.topOfText.rectTransform.anchoredPosition.y + 1 > )
            inputField.gameObject.SetActive(true);
            isFirst = true;
            if (isGoodInput == true)
                controller.DisplayRoomText();
            if (speed != 0.01 && isGoodInput == false)
                speed = 0.01;
            isGoodInput = false;
            //inputField.Select();
            textMovement.ChangeYLocation();
        }

    }

}
