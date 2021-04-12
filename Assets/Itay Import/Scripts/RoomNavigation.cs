using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{

    public Room currentRoom;

    public Room previousRoom;

    public Room startingRoom;

    public Room[] oneTimeRooms;

    public Room[] successRooms;

    public Room[] helpRooms;

    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        controller.interactionDescriptionsInRoom.Clear();
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            if(currentRoom.exits[i].exitDescription != "")
                controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

}
