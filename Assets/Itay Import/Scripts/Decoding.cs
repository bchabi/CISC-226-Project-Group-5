using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Decoding : MonoBehaviour
{

    [HideInInspector] public int decodingProgress = 0;

    public GameController controller;

    public Room successRoom;

    //bool boom = false;

    /*void completedDecoding()
    {
        controller.roomNavigation.currentRoom = successRoom;
        controller.roomNavigation.previousRoom = controller.roomNavigation.startingRoom;
    }*/

    void Update()
    {

        if (decodingProgress == controller.numberOfPatterns && controller.roomNavigation.currentRoom.roomName == "decoding")
        {
            controller.roomNavigation.currentRoom = successRoom;
            controller.roomNavigation.previousRoom = controller.roomNavigation.startingRoom;
            //boom = true;
            controller.DisplayRoomText();
            controller.DisplayLoggedText();
            controller.LogStringWithReturn(controller.fixNewLinesInDescriptions("Exiting decoding..."));
            controller.DisplayLoggedText();
            controller.textMovement.ChangeYLocation();
        }

    }
}
