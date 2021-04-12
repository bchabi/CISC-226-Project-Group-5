using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{

    public TextMeshProUGUI displayText;

    public TMP_InputField inputField;

    public GameController controller;

    TextMovement textMovement;

    RectTransform rectTransform;

    bool scrollDownPossible = false;

    float scrollDownLimit;

    RectTransform rectTransformCanvas;

    RectTransform rectTransformText;

    float fontMovement;

    public Canvas canvas;

    public TextMeshProUGUI topOfText;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textMovement = displayText.GetComponent<TextMovement>();
        fontMovement = displayText.fontSize * rectTransform.localScale.y;// rectTransform.localScale.y;
        //scrollDownLimit = rectTransform.anchoredPosition.y - rectTransform.rect.height;
        //rectTransformCanvas = canvas.GetComponent<RectTransform>();
        //rectTransformText = text.GetComponent<RectTransform>();
        //print(rectTransform.localScale.y);
        //print(displayText.fontSize);
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0 && displayText.rectTransform.anchoredPosition.y > topOfText.rectTransform.anchoredPosition.y)//displayText.rectTransform.anchoredPosition.y > rectTransformCanvas.position.y)// && //scrollDownPossible == true) //&& displayText.rectTransform.anchoredPosition.y //>= rectTransform1.anchoredPosition.y + fontMovement)
        {
            //print(displayText.rectTransform.anchoredPosition.y);
            //RectTransform rectTransform = GetComponent<RectTransform>();
            string temp = string.Join("\n", controller.actionLog.ToArray());
            int numberOfLines = temp.Split('\n').Length;//displayText.text.Split('\n').Length;
            //displayText.text = temp;
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - fontMovement);
        }
        else if (Input.mouseScrollDelta.y < 0 && displayText.rectTransform.anchoredPosition.y < textMovement.currentYCoordinate)
        {
            //print(textMovement.currentYCoordinate);
            //print(displayText.rectTransform.anchoredPosition.y);
            //RectTransform rectTransform = GetComponent<RectTransform>();
            //scrollDownPossible = true;
            string temp = string.Join("\n", controller.actionLog.ToArray());
            int numberOfLines = temp.Split('\n').Length;//displayText.text.Split('\n').Length;
            //displayText.text = temp;
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + fontMovement);
        }
    }


}
