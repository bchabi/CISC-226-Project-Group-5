using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //public int change;

    public TextMeshProUGUI displayText;

    [HideInInspector] public SlowText slowText;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string> ();
    [HideInInspector] public TextMovement textMovement;
    [HideInInspector] public Scrolling scrolling;
    public AudioSource loadingAudioSource;

    ComputerScreenUnstable unstable;
    Decoding decoding;

    public Room[] lastFilePages;

    public bool isLastComputer = false;

    /*string lastFilePage1Description = "[redacted].txt page 1:\n\nCLASSIFIED MATERIAL\nEver since the virus was introduced to the world, countries have been trying to find a cure. " +
        "Even when societies collapsed and we were left with small civilizations of just over 1000 people, there were those of us that didn’t give up. Every person doing their part from healing injured people, " +
        "to trying to find a cure to stop the destruction of life on Earth, to teaching the next generation of humans how to survive, and to fighting the creatures head on, keeping them from destroying " +
        "all that we have left. It is the will and determination of humans to survive that makes us strong. It is what allowed us to survive other deadly diseases and dangers that Mother Earth sent upon us. " +
        "This time it’s different. This virus, this disease that we created was originally made to be a symbiote with the intent to enhance our physical capabilities, to increase our ability to survive and in " +
        "turn allow us to live longer on this Earth. Instead, we created a deadly parasite that showed us what our biggest weakness is, greed. We were created with the ability to build civilizations " +
        "" +//from nothing, to manipulate raw materials to allow us to communicate from unfathomable distances, to reach places beyond our planet, yet there is one thing we can’t change, human greed. 
        "" +//The parasite tricked our bodies, used our will to survive to manipulate us to steal the lives of all other living beings on the Earth, allowing it to spread and grow. It used our will to survive 
        "" +//to make itself stronger and stole our humanity and ability to think and act freely. We beat Mother Nature but in the end, we caused our own downfall.\n\nType the word, exit, into the 
        "";//console to stop reading the file, or type the phrase, next page, into the console to continue reading the file, or type the phrase, previous page, into the console to go back to the previous page of the file*/

    string lastFilePage1Description = "[redacted].txt page 1:\n\nCLASSIFIED MATERIAL\nEver since the virus was introduced to the world, countries have been trying to find a cure. Even societies collapsed and we were left with " +
        "small civilizations of just over 1000 people, there were those of us that didn't give up. Every person doing their part from healing injured people, to trying to find a cure " +
        "to stop the destruction of life on Earth, to teaching the next generation of humans how to survive, and to fighting the creatures head on, keeping them from destroying all that we have left. " +
        "It is the will and determination of humans to survive that makes us strong. It is what allowed us to survive other deadly diseases and dangers that Mother Earth sent upon us. " +
        "This time it's different. This virus, this disease that we created was originally made to be a symbiote with the intent to enhance our physical capabilities, to increase our ability to survive " +
        "and in turn allow us to live longer on this Earth. Instead, we created a deadly parasite that showed us what our biggest weakness is, greed. We were created with the ability to " +
        "build civilizations from nothing, to manipulate raw materials to allow us to communicate from unfathomable distances, to reach places beyond our planet, yet there is one thing " +
        "we can't change, human greed. The parasite tricked our bodies, used our will to survive to manipulate us to steal the lives of all other living beings on the Earth, allowing it to " +
        "spread and grow. It used our will to survive to make itself stronger and stole our humanity and ability to think and act freely. We beat Mother Nature but in the end, we caused our own downfall." +
        "\n\nType the word, exit, into the console to stop reading the file, or type the phrase, next page, into the console to continue reading the file, or type the phrase, previous page, into the console to go back to the previous page of the file";

    string lastFilePage2Description = "[redacted].txt page 2:\n\nWe had less than 500 people left and with the new mutation, we weren't going to survive much longer. For the first time in history, " +
        "there existed something with a will to survive that was stronger than ours. We had all given up hope. Until we found a cure. Our faith in our abilities was reignited. We were brought down to our knees, " +
        "on the verge of extinction, and we now have the strength to deal the final blow that will prove that our potential is limitless and our will unbreakable. When triple checking to ensure " +
        "that our cure works before letting everyone else know and releasing it into the world, we realized something. We realized what the next mutation of the virus will be. The changes " +
        "that the virus was making to itself seemed similar to the changing effect that the cure will have on the virus. It seems that in the next mutation, the virus will no longer act parasitic. " +
        "It will evolve and rather than fight for control with its host, it will properly connect with it and act symbiotic. We were marveled by what this could mean. It would mean that we " +
        "would regain our consciousness and would be able to manipulate and use the abilities of the virus. We would be able to gain nutrients from plants and animals without needing anything " +
        "but our hands. All of our senses would be heightened and we may even start to regain our eyesight. We would be able to turn invisible to protect ourselves from wild animals. " +
        "We would be able to manipulate our black blood to create thin or thick layers on top of our skins to protect ourselves from physical damage. This would fulfill the very purpose for which " +
        "the virus was created. Then we realized what the downside would be.\n\nType the word, exit, into the console to stop reading the file, or type the phrase, next page, into the console to continue " +
        "reading the file, or type the phrase, previous page, into the console to go back to the previous page of the file";

    string lastFilePage3Description = "[redacted].txt page 3:\n\nAfter regaining consciousness we would remember simple things like how to talk, read, write, but we would lose all memory of our " +
        "life before the virus. Humanity would essentially be reset with enhanced capabilities. So we had a choice to make: cure everyone, giving them back their memories and returning everything " +
        "to the way it was before the virus was created; or we could let the virus mutate, and have humanity start over but with a better ability to survive. This decision was not easy, we had the power " +
        "to control the future of all humans. We knew that we were the ones that had to make the decision, we were the only ones who could understand where each path would lead us. We knew " +
        "that the others wouldn't consider resetting humanity. They wouldn't have the strength to make that decision, even if it is the right thing to do. After thinking about it for a long time, " +
        "considering the upsides and downsides of each decision, we finally came to a conclusion. We destroyed the cure and told the others that there wasn't anything that could be done to stop the monsters. " +
        "We also knew that for humanity to be properly reset, we had to destroy as much evidence of humans before the virus as we could. With the time that we had, we sent a virus to the safehouses " +
        "with the hopes that it will destroy all the information that was backed up on them. The monsters are going to breach the city within the hour. We won't ever know if our decision was the right " +
        "one, but it made me realize something. Maybe greed isn't a human weakness but rather a human strength. Maybe our never ending desire to want more than what we already have, our never ending " +
        "thirst to become better, our inability to be satisfied with what we already have is the reason we have survived the things that we have. Maybe our greed is what gives us goals that are " +
        "beyond our reach and our will and determination is what drives us to achieve the seemingly impossible goals. In that sense, we are truly perfect beings." +
        "\n\nType the phrase, next page, into the console to continue reading the file, or type the phrase, previous page, into the console " +
        "to go back to the previous page of the file\n\nYou can now also type the word, exit, or the word, return, into the console to leave the computer";

    bool unstableHasOccured = false;
    
    bool firstTime = true;

    public int numberOfPatterns;

    //int newTextStartingIndex = 0;

    [HideInInspector] public List<string> actionLog = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation> ();
        slowText = GetComponent<SlowText>();
        textMovement = displayText.GetComponent<TextMovement>();
        scrolling = displayText.GetComponent<Scrolling>();
        unstable = loadingAudioSource.GetComponent<ComputerScreenUnstable>();
        decoding = GetComponent<Decoding>();
        if (isLastComputer == true)
        {
            lastFilePages[0].description = lastFilePage1Description;
            lastFilePages[1].description = lastFilePage2Description;
            lastFilePages[2].description = lastFilePage3Description;
        }
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
        textMovement.ChangeYLocation();
    }

    //public int actionLogLines()
    //{
        //return string.Join("\n", actionLog.ToArray()).Split('\n').Length;
    //}

    public void DisplayLoggedText(bool isSlow=false, bool isFirst=false)//int newTextIndex = 0)
    {
        /*
        //Thread.Sleep(100);
        print(actionLog[actionLog.Count - 1]);
        //print(newTextIndex);
        if (newTextIndex == 0 && actionLog.Count == 1)
        {
            //print("y");
            displayText.text = actionLog[0].Substring(0, 1);
            DisplayLoggedText(1);
        }
        else if (newTextIndex < actionLog[actionLog.Count - 1].Length)
        {
            //print(actionLog[actionLog.Count - 1].Substring(newTextIndex, 1));
            displayText.text += actionLog[actionLog.Count - 1].Substring(newTextIndex, 1);
            DisplayLoggedText(newTextIndex + 1);
        }
        else if(newTextIndex == actionLog[actionLog.Count - 1].Length)
        {
            print(displayText.text);
        }*/
        //print(logAsText);
        //print(newTextStartingIndex);
        //print(logAsText.Substring(newTextStartingIndex, 1));
        /*for (int i = newTextStartingIndex; i < logAsText.Length; i++)
        {
            //print(logAsText.Substring(i, 1));
            //print(i);
            displayText.text = displayText.text + logAsText.Substring(i, 1);
            if (logAsText.Substring(i, 1).Equals("\n") && actionLog.Count > 1)
                displayText.text.TrimEnd('\n');
            //print(displayText.text);
            //WaitForSeconds(0.5);
            //Thread.Sleep(50);
        }*/



        string logAsText;// = string.Join("\n", actionLog.ToArray());

        /*string[] arrayActionLog = new string[actionLog.ToArray().Length - (slowText.initialSize - slowText.stringToPrint.Length) - 1];

        string[] temp1 = actionLog.ToArray();

        if (displayText.rectTransform.anchoredPosition.y >= 1500)
        {
            for (int i = 1 + (slowText.initialSize - slowText.stringToPrint.Length); i < temp1.Length; i++)
            {
                arrayActionLog[i - 1] = temp1[i];
            }
        }*/

        if (isSlow == true)
        {
            /*for (int i = 1; i < logAsText.Length; i = i + 2)
            {
                print("Length: " + logAsText.Length);
                print("String: " + logAsText);
                if (i == logAsText.Length - 1) // && logAsText[i] == '\n')
                    logAsText = logAsText.Substring(0, logAsText.Length - 1);
                else //if (logAsText[i] == '\n')
                    logAsText = logAsText.Substring(0, i) + logAsText.Substring(i + 1, logAsText.Length - i - 1);
            }*/

            if (isFirst == true)
                logAsText = string.Join("\n", actionLog.ToArray());//arrayActionLog);
            else
            {
                //print("Count: " + actionLog.Count);
                //print("String: " + string.Join("\n", actionLog.ToArray()));
                //print("Part 1: " + actionLog[0]);
                //print("Part 2: " + actionLog[1]);
                string temp = actionLog[actionLog.Count - 2] + actionLog[actionLog.Count - 1];
                actionLog.RemoveAt(actionLog.Count - 1);
                actionLog.RemoveAt(actionLog.Count - 1);
                actionLog.Add(temp);
            }


        }
        //print(actionLog[0]);
        logAsText = string.Join("\n", actionLog.ToArray());//arrayActionLog);

        /*if (displayText.rectTransform.anchoredPosition.y > scrolling.topOfText.rectTransform.anchoredPosition.y + textMovement.fontSize*6)
        {
            int newLineCounter = 0;
            int characterCounter = 0;
            while(newLineCounter < 4)
            {
                if (logAsText[characterCounter] == '\n')
                    newLineCounter = newLineCounter + 1;
                characterCounter = characterCounter + 1;
            }
            logAsText = logAsText.Substring(characterCounter, logAsText.Length - characterCounter);
        }*/

        displayText.text = logAsText;

        for (int i = 0; i < roomNavigation.oneTimeRooms.Length; i++)
        {
            if (roomNavigation.currentRoom.roomName == roomNavigation.oneTimeRooms[i].roomName && slowText.isGoodInput == false)//"help")
                roomNavigation.currentRoom = roomNavigation.previousRoom;
        }

        for (int i = 0; i < roomNavigation.successRooms.Length; i++)
        {
            //print(roomNavigation.currentRoom.roomName);
            //print(roomNavigation.successRooms[i].roomName);
            if (roomNavigation.currentRoom.roomName == roomNavigation.successRooms[i].roomName)//"help")
                roomNavigation.currentRoom = roomNavigation.previousRoom;
        }

        if(SceneManager.GetActiveScene().name == "Computer 1" && decoding.decodingProgress >= 2 && unstableHasOccured == false)
        {
            unstable.enabled = true;//.gameObject.SetActive(true);
            unstable.startingTime = Time.fixedTime;
            unstableHasOccured = true;
        }


        //print(roomNavigation.currentRoom.roomName);
        /*if (roomNavigation.currentRoom.roomName == roomNavigation.successRooms[roomNavigation.successRooms.Length - 1].roomName)
        {
            //print("y");
            roomNavigation.currentRoom = roomNavigation.startingRoom;
        }*/
    }

    public void DisplayRoomText()
    {

        UnpackRoom();

        
        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        if (SceneManager.GetActiveScene().name == "Computer 2" && firstTime == true)
        {
            joinedInteractionDescriptions = joinedInteractionDescriptions + "\nType \"hint\" for guidance on next step";
            firstTime = false;
        }

        //print(roomNavigation.currentRoom.description);
        //print(joinedInteractionDescriptions);
        string combinedText = "";
        //print(roomNavigation.currentRoom.description);
        //if(roomNavigation.currentRoom.roomName != "help") {
        //print(joinedInteractionDescriptions);
        if (joinedInteractionDescriptions.Length != 0 && joinedInteractionDescriptions.Substring(joinedInteractionDescriptions.Length - 1, 1) == "\n")
        {
            //print("1");
            //print(joinedInteractionDescriptions);
            joinedInteractionDescriptions =  joinedInteractionDescriptions.Substring(0, joinedInteractionDescriptions.Length - 1);
            //print(joinedInteractionDescriptions);
        }
        if (joinedInteractionDescriptions != "")
        {
            //print("2");
            combinedText = fixNewLinesInDescriptions(roomNavigation.currentRoom.description) + "\n" + joinedInteractionDescriptions;
        }
        else
        {
            //print("3");
            combinedText = fixNewLinesInDescriptions(roomNavigation.currentRoom.description);
        }
        //print(combinedText);
        //slowText.computerText = combinedText;
        //slowText.printSlowText();
        //DisplayLoggedText();
        //}
        //print(displayText.text);

        LogStringWithReturn(combinedText);
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        /*if (actionLog.Count > 0)
        {
            newTextStartingIndex = newTextStartingIndex + actionLog[actionLog.Count - 1].Length;
            //print(newTextStartingIndex);
            //print(actionLog[actionLog.Count - 1].Length);
        }*/
        //print("User Input:" + stringToAdd);
        //print(stringToAdd);
        slowText.startSlow(stringToAdd + "\n");
        //actionLog.Add(stringToAdd + "\n");

        /*print(actionLog[0]);
        print(actionLog[actionLog.Count - 1]);
        print(string.Join("\n", actionLog.ToArray()));
        print(string.Join("\n", actionLog.ToArray()).Substring(newTextStartingIndex, 0));*/
        //print(string.Join("\n", actionLog.ToArray()).Substring(newTextStartingIndex, 1));
        //if (actionLog.Count > 1)
        //print(string.Join("\n", actionLog.ToArray()).Substring(newTextStartingIndex - 3, 4));
        //if(actionLog.Count > 1)
        //newTextStartingIndex = newTextStartingIndex + actionLog[actionLog.Count - 1].Length;
        //print(actionLog[newTextStartingIndex]);
        //print(newTextStartingIndex);
    }

    public string fixNewLinesInDescriptions(string description)
    {
        string newDescription = "";
        string tempWord = "";
        int counter = 0;
        for (int i = 0; i < description.Length; i++)
        {
            //print("i = " + i);
            //print("description[i] = " + description[i]);
            if (description[i] == ' ' && i != description.Length - 1)
            {
                if (counter > 85) //Used to be 34
                {
                    //print("what");
                    newDescription = newDescription + "\n" + tempWord;
                    counter = tempWord.Length;
                }
                else if (counter != tempWord.Length)
                {
                    //print("yes");
                    newDescription = newDescription + " " + tempWord;
                }
                else if (counter == tempWord.Length)
                {
                    if (newDescription == "")
                        newDescription = tempWord;
                    else
                        newDescription += tempWord;
                }
                /*else
                {
                    print("no");
                    newDescription += tempWord;
                }*/

                tempWord = "";
            }
            else if (description[i] == '\n' && i != description.Length - 1)
            {
                /*if (i != description.Length - 1)
                {
                    newDescription = newDescription + tempWord + "\n";
                    counter = 0;
                }
               /else
                    newDescription += tempWord;*/

                if (counter > 85) //Used to be 34
                {
                    //print("get");
                    newDescription = newDescription + "\n" + tempWord;
                    counter = tempWord.Length - 1;
                }
                else if(counter == tempWord.Length)
                {
                    newDescription = newDescription + tempWord + "\n";
                    counter = -1;
                }
                else
                {
                    //print("me out");
                    newDescription = newDescription + " " + tempWord + "\n";
                    counter = -1;
                }

                tempWord = "";
            }
            else //if(description[i].ToString() != "")
            {
                tempWord += description[i];
            }

                /*newDescription += description[i];

                if (description[i] == '\n')
                    counter = 0;

                if ((counter + 1) % 35 == 0)
                    newDescription += "\n";*/

                counter += 1;
        }

        if(tempWord != "")
        {

            if (counter > 85) //Used to be 34
                newDescription = newDescription + "\n" + tempWord;
            else if (counter == tempWord.Length)
                newDescription += tempWord;
            else
                newDescription = newDescription + " " + tempWord;

        }

        return newDescription;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
