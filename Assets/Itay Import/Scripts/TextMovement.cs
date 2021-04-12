using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMovement : MonoBehaviour
{

    public TMP_InputField inputField;

    public GameController controller;

    RectTransform rectTransform;

    float startingXCoordinate;

    float startingYCoordinate;

    [HideInInspector] public float currentYCoordinate;

    [HideInInspector] public float fontSize;

    [HideInInspector] public float fontScale;

    [HideInInspector] public float numberOfMovements;

    //float startingText;

    //int height;

    //[HideInInspector] public int adjustForExtraSpace;

    void Start()//Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        TextMeshProUGUI displayText = GetComponent<TextMeshProUGUI>();
        fontScale = rectTransform.localScale.y;
        fontSize = displayText.fontSize * fontScale;//textBox.rectTransform.localScale;
        int numberOfLines = controller.roomNavigation.currentRoom.description.Split('\n').Length + 1;//displayText.text.Split('\n').Length;//controller.actionLogLines();//
        numberOfMovements = numberOfLines;
        for (int i = 0; i < controller.roomNavigation.currentRoom.exits.Length; i++)
        {
            //print(controller.roomNavigation.currentRoom.exits[i].exitDescription);
            if(controller.roomNavigation.currentRoom.exits[i].exitDescription != "")
                numberOfLines += controller.roomNavigation.currentRoom.exits[i].exitDescription.Split('\n').Length;
            //print(numberOfLines);
            //print(controller.roomNavigation.currentRoom.exits[i].exitDescription);
        }
        //print(numberOfLines);

        float textOffset = 0;

        if (numberOfLines > 3)
            textOffset = fontSize * (numberOfLines - 3);

        startingXCoordinate = rectTransform.anchoredPosition.x;
        startingYCoordinate = rectTransform.anchoredPosition.y + textOffset - fontSize * numberOfLines;
        //print(rectTransform.anchoredPosition.y);
        //print(startingYCoordinate);
        currentYCoordinate = rectTransform.anchoredPosition.y;
        //print(fontSize);
        //print(numberOfLines);
        //print(startingXCoordinate);
        //print(startingYCoordinate);
        //RectTransform temp = GetComponent<RectTransform>();
        //float height = temp.rect.height;
        //controller = GetComponent<GameController>();
        //print(controller);
        //inputField.onEndEdit.AddListener(ChangeYLocation);
    }

    public void ChangeYLocation()//string ignore)
    {
        //print(controller.change);
        //RectTransform rectTransform1 = GetComponent<RectTransform>();
        int numberOfLines = controller.displayText.text.Split('\n').Length;
        //print(controller.displayText.text);
        //print(numberOfLines);
        numberOfMovements = numberOfLines;
        currentYCoordinate = startingYCoordinate + numberOfLines * fontSize;
        //print(adjustForExtraSpace);
        //print(rectTransform1.sizeDelta);
        rectTransform.anchoredPosition = new Vector2(startingXCoordinate, currentYCoordinate);
        //rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 123.5f - 15 * 4f + numberOfLines * 15f); //- adjustForExtraSpace);
        //print(rectTransform1.sizeDelta);
        //rectTransform1.sizeDelta = new Vector2(rectTransform1.sizeDelta.x, height + numberOfLines * 15f/2f);
        //rectTransform1.sizeDelta = new Vector2(rectTransform1.rect.width, (height - 15 * 4f + numberOfLines * 15f)/2);
        //print(rectTransform1.sizeDelta);
        //rectTransform1.sizeDelta = new Vector2(0, (numberOfLines * 15f) / 2);
        //print((height - 15 * 4f + numberOfLines * 15f) / 2);
        //rectTransform1.rect.Set(rectTransform1.rect.x, rectTransform1.rect.y, rectTransform1.rect.width, (height - 15 * 4f + numberOfLines * 15f) / 2f);
        //rectTransform1.ForceUpdateRectTransforms();

        /*if(controller.change == 0)
        {
            rectTransform1.anchoredPosition = new Vector2(rectTransform1.anchoredPosition.x, rectTransform1.anchoredPosition.y + 30);
        }
        else if(controller.change == 1)
        {
            rectTransform1.anchoredPosition = new Vector2(rectTransform1.anchoredPosition.x, rectTransform1.anchoredPosition.y + 45);
        }*/
    }

}
