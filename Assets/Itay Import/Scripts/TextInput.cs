using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextInput : MonoBehaviour
{

    //public SceneManager sceneManager;

    public TMP_InputField inputField;

    public GameController controller;

    List<string> completedPatterns = new List<string>();

    public string scene;

    bool patternAlreadyFound = false;

    Decoding decoding;

    //public AudioSource audioSource;

    TextMovement textMovement;

    [HideInInspector] public bool exitCondition = false;

    KeyboardSound keyboardSound;

    bool clearScreen = false;

    bool hintRequest = false;

    bool isBreak = false;

    int hints = 1;

    void Awake()
    {
        //controller = GetComponent<GameController>();
        textMovement = controller.displayText.GetComponent<TextMovement>();
        decoding = controller.GetComponent<Decoding>();
        keyboardSound = inputField.GetComponent<KeyboardSound>();
        //inputField.onEndEdit.AddListener(AcceptStringInput);
        inputField.onSubmit.AddListener(AcceptStringInput);
    }

    private void Update()
    {
        //if (inputField.text.Length > 35)
        //inputField.text = inputField.text.Substring(0, 35);
        //THIS IS GONE BECAUSE OF THE SIMPLE SENTENCE REORDERING
        if (inputField.gameObject.active == true)
            inputField.ActivateInputField();
    }

    void AcceptStringInput(string userInput)
    {
        if (userInput == "return")
            keyboardSound.returnInput = true;
        //controller.change = 0;
        userInput = userInput.ToLower();
        //print("Input:" + userInput);
        bool roomChange = false;
        patternAlreadyFound = false;
        isBreak = false;

        //controller.LogStringWithReturn(userInput);

        //textMovement.ChangeYLocation("");

        if (SceneManager.GetActiveScene().name == "Computer 2")
        {
            if (hints == 1 && userInput == "hint")
            {
                userInput = userInput + "\n\nTry looking through the files for information";
                hintRequest = true;
            }
            else if (hints == 2 && userInput == "hint")
            {
                userInput = userInput + "\n\nTry decoding the files";
                hintRequest = true;
            }
            else if (hints >= 3 && hints <= 5 && userInput == "hint")
            {
                if (completedPatterns.Count == 0)
                    userInput = userInput + "\n\nTry looking at the number of letters in the strings";
                else if (completedPatterns.Contains("nbr 4") == false)
                    userInput = userInput + "\n\nTry looking at the number of letters in the strings";
                else if (completedPatterns.Contains("bgn b") == false)
                    userInput = userInput + "\n\nTry looking at the beginning of the strings";
                else if (completedPatterns.Contains("cct g-r") == false)
                    userInput = userInput + "\n\nTry looking for letters that always show up next to each other";
                hintRequest = true;
            }
            else if (hints == 6 && userInput == "hint")
            {
                userInput = userInput + "\n\nTry opening the files";
                hintRequest = true;
            }


            if (hints == 1 && (userInput == "opn abkmdow.txt" || userInput == "opn awkshafk.txt" || userInput == "opn tomwogw.txt" || userInput == "opn qgjelgreg.txt" || userInput == "opn mfihgdwt.txt"))
                hints += 1;
            else if (hints == 2 && userInput == "dcd+")
                hints += 1;
            else if (hints >= 3 && hints <= 5 && (userInput == "nbr 4" || userInput == "bgn b" || userInput == "cct g-r"))
                hints += 1;
        }


        for (int i = 0; i < controller.roomNavigation.currentRoom.exits.Length; i++)
        {
            for (int j = 0; j < controller.roomNavigation.currentRoom.exits[i].keyString.Length; j++)
            {
                if (userInput.Equals(controller.roomNavigation.currentRoom.exits[i].keyString[j]))
                {
                    for (int k = 0; k < controller.roomNavigation.oneTimeRooms.Length; k++)
                    {
                        if (controller.roomNavigation.currentRoom.exits[i].valueRoom.roomName == controller.roomNavigation.oneTimeRooms[k].roomName)//"help")
                            controller.roomNavigation.previousRoom = controller.roomNavigation.currentRoom;//exits[i].valueRoom;
                    }

                    if ((controller.roomNavigation.currentRoom.exits[i].keyString[j] == "exit decoding" && (controller.roomNavigation.currentRoom.roomName == "simple decoding" || controller.roomNavigation.currentRoom.roomName == "simple decoding 1" 
                        || controller.roomNavigation.currentRoom.roomName == "simple decoding 2")) || controller.roomNavigation.currentRoom.exits[i].keyString[j] == "dcd-")
                        controller.roomNavigation.previousRoom = controller.roomNavigation.startingRoom;
                    else if ((controller.roomNavigation.currentRoom.exits[i].keyString[j] == "iwtfdggyfp" || controller.roomNavigation.currentRoom.exits[i].keyString[j] == "IWTFDGGYFP") && controller.roomNavigation.currentRoom.roomName == "last third password")
                        controller.roomNavigation.previousRoom = controller.roomNavigation.startingRoom;

                    for (int k = 0; k < controller.roomNavigation.successRooms.Length; k++)
                    {
                        if (controller.roomNavigation.currentRoom.exits[i].valueRoom.roomName == controller.roomNavigation.successRooms[k].roomName && controller.roomNavigation.currentRoom.roomName == "decoding")//"help")
                        {
                            if (completedPatterns.Count > 0)
                            {
                                for (int l = 0; l < completedPatterns.Count; l++)
                                {
                                    if (controller.roomNavigation.currentRoom.exits[i].valueRoom.roomName == completedPatterns[l])
                                        patternAlreadyFound = true;

                                }
                            }

                            if (patternAlreadyFound == false)
                            {
                                controller.roomNavigation.previousRoom = controller.roomNavigation.currentRoom;//exits[i].valueRoom;
                                decoding.decodingProgress += 1;
                                completedPatterns.Add(controller.roomNavigation.currentRoom.exits[i].valueRoom.roomName);
                            }
                            //print(decoding.decodingProgress);
                        }
                    }
                    roomChange = true;
                    //print("asdfas: " + controller.roomNavigation.currentRoom.exits[i].valueRoom);
                    controller.roomNavigation.currentRoom = controller.roomNavigation.currentRoom.exits[i].valueRoom;

                    if (controller.roomNavigation.currentRoom.roomName == "last file third page")
                        exitCondition = true;

                    //controller.DisplayRoomText();
                    //textMovement.adjustForExtraSpace = 5;
                    isBreak = true;
                    break;
                    //controller.change = 1;
                    //textMovement.ChangeYLocation("");
                }
                //else
                //{
                //textMovement.adjustForExtraSpace = 0;
                //}
            }
            if (isBreak == true)
                break;
        }
        //controller.change = -1;
        print("User input: " + userInput);
        print(controller.roomNavigation.currentRoom.name);
        if (roomChange == true && patternAlreadyFound == false)
        {
            controller.LogStringWithReturn(userInput);
            controller.slowText.isGoodInput = true;
            //controller.DisplayRoomText();
        }
        else if(SceneManager.GetActiveScene().name.Equals("Computer 3"))
        {
            string temp = "";
            if (controller.roomNavigation.currentRoom.roomName == "simple decoding" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 0)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You are missing some words in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 1)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You have some extra spaces in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 2)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You have some extra words in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 3)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You are misspelling at least one word");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple start room ad" && userInput == "open mfihgdwt.txt")
            {
                temp = controller.fixNewLinesInDescriptions("The file is partially corrupted, finding all intact data" + "\n\n" + "File mfihgdwt.txt:\n\"-------seem invisible. It’s nearly impossible to see them. " +
                    "Their loud footsteps is the only--------can’t see. Best thing to do is not move if you hear them. DO NOT RUN.--------\"\n\n\nYou can now type the word, exit, into the console to leave the computer");
                exitCondition = true;
            }
            else if (userInput == "exit" && exitCondition == true)
                SceneManager.LoadScene(scene);
            else if (controller.roomNavigation.currentRoom.roomName == "simple start room" || controller.roomNavigation.currentRoom.roomName == "simple start room ad")
                temp = controller.fixNewLinesInDescriptions("You appear to be using a command incorrectly, make sure to read the descriptions of the commands, by typing the word, commands, into the console, to understand how to use the commands");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding" && userInput.Length == 5 && userInput.Substring(0, 5) == "files")
                temp = controller.fixNewLinesInDescriptions("The command, files, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding" && userInput.Length >= 4 && userInput.Substring(0, 4) == "open")
                temp = controller.fixNewLinesInDescriptions("The command, open, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding" && userInput.Length >= 6 && userInput.Substring(0, 6) == "decode")
                temp = controller.fixNewLinesInDescriptions("The command, decode, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else
                temp = controller.fixNewLinesInDescriptions("The sentence you wrote seems to be in the wrong order");//, make sure that you are not missing any words");
            controller.LogStringWithReturn(userInput + "\n\n" + temp);
            //controller.LogStringWithReturn(temp);
        }
        else if (SceneManager.GetActiveScene().name.Equals("Computer 4"))
        {
            string temp = "";
            if (controller.roomNavigation.currentRoom.roomName == "simple decoding 1" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 0)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You are missing some words in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 1" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 1)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You have some extra spaces in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 1" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 2)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You have some extra words in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 1" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 3)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You are misspelling at least one word");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple start room ad 1" && userInput == "open iafctg.txt")
            {
                temp = controller.fixNewLinesInDescriptions("The file is partially corrupted, finding all intact data" + "\n\n" + "File iafctg.txt:\n\"-------Patient Zero. He seems to not be reacting-------decreased eyesight, " +
                    "increased hearing, sme-------drained all the blood out of the body. It then secretes its own blood into------type of virus. Patient Zero would be the first one to mutate------\"\n\n\nYou can now type the " +
                    "word, exit, into the console to leave the computer");
                exitCondition = true;
            }
            else if (userInput == "exit" && exitCondition == true)
                SceneManager.LoadScene(scene);
            else if (controller.roomNavigation.currentRoom.roomName == "simple start room 1" || controller.roomNavigation.currentRoom.roomName == "simple start room ad 1")
                temp = controller.fixNewLinesInDescriptions("You appear to be using a command incorrectly, make sure to read the descriptions of the commands, by typing the word, commands, into the console, to understand how to use the commands");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 1" && userInput.Length == 5 && userInput.Substring(0, 5) == "files")
                temp = controller.fixNewLinesInDescriptions("The command, files, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 1" && userInput.Length >= 4 && userInput.Substring(0, 4) == "open")
                temp = controller.fixNewLinesInDescriptions("The command, open, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 1" && userInput.Length >= 6 && userInput.Substring(0, 6) == "decode")
                temp = controller.fixNewLinesInDescriptions("The command, decode, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else
                temp = controller.fixNewLinesInDescriptions("The sentence you wrote seems to be in the wrong order");
            controller.LogStringWithReturn(userInput + "\n\n" + temp);
            //controller.LogStringWithReturn(temp);
        }
        else if (SceneManager.GetActiveScene().name.Equals("Computer 5"))
        {
            string temp = "";
            if (controller.roomNavigation.currentRoom.roomName == "simple decoding 2" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 0)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You are missing some words in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 2" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 1)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You have some extra spaces in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 2" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 2)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You have some extra words in your sentence");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 2" && checkSimpleSentence(userInput, controller.roomNavigation.currentRoom.exits[0].keyString[0]) == 3)
            {
                //print(controller.roomNavigation.currentRoom.exits[0].keyString[0]);
                temp = controller.fixNewLinesInDescriptions("You are misspelling at least one word");
            }
            else if (controller.roomNavigation.currentRoom.roomName == "simple start room ad 2" && userInput == "open irwmdwh.txt")
            {
                temp = controller.fixNewLinesInDescriptions("The file is partially corrupted, finding all intact data" + "\n\n" + "File irwmdwh.txt:\n\"------automatically backed up. The wooden structure of these cabins " +
                    "allows them to work as good safehouses as the creatures see these cabins as dead trees in the middle of a forest full of live ones. This allows all of our information to be hidden in plain sight " +
                    "and------memory. This means that we can only backup information vital to the continued survival of humanity and that there is a chance that all information about the history of humans may be lost " +
                    "if we are ever overrun. Unfortunately-------4 separate ones. This way if one place is destroyed, not all information is lost, Thankfully-----is how we connect with the computers. Unfortunately, due " +
                    "to our limited resources, these old computers are the only ones we could spare. They work but-----\"\n\n\nYou can now type the word, exit, into the console to leave the computer");
                exitCondition = true;
            }
            else if (userInput == "exit" && exitCondition == true)
                SceneManager.LoadScene(scene);
            else if (controller.roomNavigation.currentRoom.roomName == "simple start room 2" || controller.roomNavigation.currentRoom.roomName == "simple start room ad 2")
                temp = controller.fixNewLinesInDescriptions("You appear to be using a command incorrectly, make sure to read the descriptions of the commands, by typing the word, commands, into the console, to understand how to use the commands");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 2" && userInput.Length == 5 && userInput.Substring(0, 5) == "files")
                temp = controller.fixNewLinesInDescriptions("The command, files, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 2" && userInput.Length >= 4 && userInput.Substring(0, 4) == "open")
                temp = controller.fixNewLinesInDescriptions("The command, open, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else if (controller.roomNavigation.currentRoom.roomName == "simple decoding 2" && userInput.Length >= 6 && userInput.Substring(0, 6) == "decode")
                temp = controller.fixNewLinesInDescriptions("The command, decode, can't be used while in the decoding process, to use it you must exit the decoding process by typing the following into the console,\nexit decoding");
            else
                temp = controller.fixNewLinesInDescriptions("The sentence you wrote seems to be in the wrong order");
            controller.LogStringWithReturn(userInput + "\n\n" + temp);
            //controller.LogStringWithReturn(temp);
        }
        else if (SceneManager.GetActiveScene().name.Equals("Computer 6"))
        {
            string temp = "";
            if(userInput == "return" && exitCondition == false)
                temp = controller.fixNewLinesInDescriptions("Saving progress...\nProgress saved");
            else if (controller.roomNavigation.currentRoom.roomName == "last first password" || controller.roomNavigation.currentRoom.roomName == "last second password" || controller.roomNavigation.currentRoom.roomName == "last third password")
                temp = controller.fixNewLinesInDescriptions("Checking password...\nPassword incorrect");
            else if(controller.roomNavigation.currentRoom.roomName == "last file first page" && userInput == "previous page")
                temp = controller.fixNewLinesInDescriptions("You are already on the first page");
            else if (controller.roomNavigation.currentRoom.roomName == "last file third page" && userInput == "next page")
                temp = controller.fixNewLinesInDescriptions("You are already on the last page");
            else if(exitCondition == true && (userInput == "exit" || userInput == "return"))
                SceneManager.LoadScene(scene);
            else if (controller.roomNavigation.currentRoom.roomName == "last file first page" || controller.roomNavigation.currentRoom.roomName == "last file second page" || controller.roomNavigation.currentRoom.roomName == "last file third page")
                temp = controller.fixNewLinesInDescriptions("You are using a command incorrectly, either type into the console exit, previous page, or next page");
            else
                temp = controller.fixNewLinesInDescriptions("You appear to be using a command incorrectly, make sure to read the descriptions of the commands, by typing the word, commands, into the console, to understand how to use the commands");
            controller.LogStringWithReturn(userInput + "\n\n" + temp);
        }
        else if (hintRequest == false)
        {
            string temp = "";
            if (patternAlreadyFound == true)
                temp = controller.fixNewLinesInDescriptions("Error:" + "\n" + "Pattern has already been found");
            else if (userInput.Length >= 3 && controller.roomNavigation.currentRoom.roomName == "decoding" && (userInput == "fls" || userInput.Substring(0, 3) == "opn"))
                temp = controller.fixNewLinesInDescriptions("The command \"" + userInput.Substring(0, 3) + "\" can't be used while decoding");
            else if (userInput.Length == 4 && controller.roomNavigation.currentRoom.roomName == "decoding" && userInput.Substring(0, 4) == "dcd+")
                temp = controller.fixNewLinesInDescriptions("The command \"dcd+\" can't be used while decoding");
            else if (userInput.Length == 4 && controller.roomNavigation.currentRoom.roomName == "start room" && userInput.Substring(0, 4) == "dcd-")
                temp = controller.fixNewLinesInDescriptions("The command \"dcd-\" can't be used while not decoding");
            else if (decoding.decodingProgress != controller.numberOfPatterns && (userInput == "opn abkmdow.txt" || userInput == "opn awkshafk.txt" || userInput == "opn tomwogw.txt" || userInput == "opn qgjelgreg.txt" || userInput == "opn mfihgdwt.txt"))
                temp = controller.fixNewLinesInDescriptions("File encoded\nDecoding necessary");
            else if (decoding.decodingProgress == controller.numberOfPatterns && (userInput == "opn abkmdow.txt" || userInput == "opn awkshafk.txt" || userInput == "opn tomwogw.txt" || userInput == "opn qgjelgreg.txt"))
                temp = controller.fixNewLinesInDescriptions("Error:\nFile Corrupted");
            else if (decoding.decodingProgress == controller.numberOfPatterns && userInput == "opn mfihgdwt.txt")
            {
                temp = controller.fixNewLinesInDescriptions("Error:" + "\n" + "File partially corrupted, decoding intact data" + "\n" + "File \"mfihgdwt.txt\":\n\"-------seem invisible. It’s nearly impossible to see them. " +
                    "Their loud footsteps is the only--------can’t see. Best thing to do is not move if you hear them. DO NOT RUN.--------\"\n\n\nYou can now type \"exit\" to leave");
                exitCondition = true;
            }
            else if (controller.roomNavigation.currentRoom.roomName == "decoding" && userInput.Length >= 3 && (userInput.Substring(0, 3) == "nbr" || userInput.Substring(0, 3) == "cct" || userInput.Substring(0, 3) == "bgn" ||
                userInput.Substring(0, 3) == "end" || userInput.Substring(0, 3) == "vpn" || userInput.Substring(0, 3) == "cwm"))
            {
                if ((userInput.Substring(0, 3) == "bgn" || userInput.Substring(0, 3) == "end") && checkBGNEND(userInput) == true)
                    temp = controller.fixNewLinesInDescriptions("The pattern is incorrect");
                else if ((userInput.Substring(0, 3) == "nbr" || userInput.Substring(0, 3) == "vpn") && checkNBRVPN(userInput) == true)
                    temp = controller.fixNewLinesInDescriptions("The pattern is incorrect");
                else if (userInput.Substring(0, 3) == "cct" && checkCCT(userInput) == true)
                    temp = controller.fixNewLinesInDescriptions("The pattern is incorrect");
                else if (userInput.Substring(0, 3) == "cwm" && checkCWM(userInput) == true)
                    temp = controller.fixNewLinesInDescriptions("The pattern is incorrect");
                else
                    temp = controller.fixNewLinesInDescriptions("Error:\nThe command \"" + userInput.Substring(0, 3) + "\" is being used incorrectly"); //THIS IS ORIGINAL BOOM
            }
            //else if (userInput.Length >= 4 && controller.roomNavigation.currentRoom.roomName == "decoding" && (userInput.Substring(0, 4) == "nbr " || userInput.Substring(0, 4) == "cct " ||
            //userInput.Substring(0, 4) == "bgn " || userInput.Substring(0, 4) == "end " || userInput.Substring(0, 4) == "vpn " || userInput.Substring(0, 4) == "cwm "))
            //temp = controller.fixNewLinesInDescriptions("Error:\nThe command \"" + userInput + "\" may have been used incorrectly or pattern may be incorrect");
            else if (userInput.Length >= 4 && controller.roomNavigation.currentRoom.roomName == "start room" && (userInput.Substring(0, 4) == "nbr " || userInput.Substring(0, 4) == "cct " ||
                userInput.Substring(0, 4) == "bgn " || userInput.Substring(0, 4) == "end " || userInput.Substring(0, 4) == "vpn " || userInput.Substring(0, 4) == "cwm "))
                temp = controller.fixNewLinesInDescriptions("Error:\nThe command \"" + userInput.Substring(0, 3) + "\" may only be used during decoding");
            else if (userInput == "exit" && exitCondition == true)
                SceneManager.LoadScene(scene);
            else if (userInput == "clc")
                clearScreen = true;
            else
                temp = controller.fixNewLinesInDescriptions("Unknown command: \"" + userInput + "\"");
            //if (userInput.Length >= 3 && controller.roomNavigation.currentRoom.roomName == "decoding" && userInput.Substring(0, 3) == "opn")
            //temp = controller.fixNewLinesInDescriptions("The command \"opn\" can't be used while decoding");
            //if(userInput.Length >= 4 && (userInput.Substring(0, 4) == "hlp " || userInput.Substring(0, 4) == "dcd+ " || userInput.Substring(0, 4) == "fls " || userInput.Substring(0, 4) == "opn " ||
            //userInput.Substring(0, 4) == "nbr " || userInput.Substring(0, 4) == "cct " || ))
            controller.LogStringWithReturn(userInput);
            controller.LogStringWithReturn(temp);
        }
        if (clearScreen == true)
        {
            controller.actionLog.Clear();
            clearScreen = false;
        }
        if(hintRequest == true)
        {
            controller.LogStringWithReturn(userInput);
            hintRequest = false;
        }
        InputComplete();
        //controller.LogStringWithReturn(userInput);
        textMovement.ChangeYLocation();//"");
        print(controller.roomNavigation.currentRoom.name);
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

    int checkSimpleSentence(string input, string sentence)
    {
        bool hasExtraSpace = false;
        if (input.Length == 0 || input.Length == 1)
            return 0;
        if (input[0] == ' ')
        {
            input = input.Substring(1, input.Length - 1);
            hasExtraSpace = true;
        }
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == ' ' && i != input.Length - 1 && input[i + 1] == ' ')
            {
                //print(input);
                input = input.Substring(0, i) + input.Substring(i + 1, input.Length - i - 1);
                //print(input);
                i = i - 1;
                hasExtraSpace = true;
            }
            if (i == input.Length - 1 && input[i] == ' ')
                input = input.Substring(0, i);
        }

        string[] inputArray = input.Split(' ');
        string[] sentenceArray = sentence.Split(' ');
        int inputLength = inputArray.Length;
        bool temp = false;

        if (inputLength < sentenceArray.Length)
            return 0;
        else if (inputLength > sentenceArray.Length)
            return 2;
        if (input.Length != sentence.Length)
            return 3;

        for (int i = 0; i < inputLength; i++)
        {
            for (int j = 0; j < sentenceArray.Length; j++)
            {
                print("Input array " + i + ": " + inputArray[i]);
                print("Sentence array " + j + ": " + sentenceArray[j]);
                if (inputArray[i] == sentenceArray[j])
                {
                    inputArray[i] = null;
                    sentenceArray[j] = null;
                    temp = true;
                    break;
                }
            }
            if (temp == true)
                temp = false;
            else
                return 0;
        }

        if (hasExtraSpace == true)
            return 1;

        return 4;
    }

    bool isIn(char charToCheck, string checkInside)
    {
        for (int i = 0; i < checkInside.Length; i++)
        {
            if (charToCheck == checkInside[i])
                return true;
        }
        return false;
    }

    bool checkNumbers(string userInput)
    {
        string numbers = "0123456789";
        for (int i = 0; i < userInput.Length; i++)
        {
            if (!isIn(userInput[i], numbers))
                return false;
        }
        return true;
    }

    bool checkLetters(string userInput)
    {
        string letters = "abcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < userInput.Length; i++)
        {
            if (!isIn(userInput[i], letters))
                return false;
        }
        return true;
    }

    bool checkNBRVPN(string userInput)
    {
        if (userInput.Length <= 4)
            return false;
        return checkNumbers(userInput.Substring(4, userInput.Length - 4));
    }

    bool checkBGNEND(string userInput)
    {
        if (userInput.Length <= 4)
            return false;
        return checkLetters(userInput.Substring(4, userInput.Length - 4));
    }

    bool checkCCT(string userInput)
    {
        if (userInput.Length <= 6)
            return false;
        int index = 4;
        bool hasDash = false;
        while (index < userInput.Length)
        {
            if (userInput[index] == '-')
            {
                hasDash = true;
                break;
            }
            index = index + 1;
        }
        if (hasDash == false || checkLetters(userInput.Substring(4, index - 4)) == false || checkLetters(userInput.Substring(index + 1, userInput.Length - index - 1)) == false)
            return false;
        return true;
    }

    bool checkCWM(string userInput)
    {
        if (userInput.Length <= 8)
            return false;
        int index1 = 4;
        bool hasSlash = false;
        while (index1 < userInput.Length)
        {
            if (userInput[index1] == '/')
            {
                hasSlash = true;
                break;
            }
            index1 = index1 + 1;
        }
        if (hasSlash == false)
            return false;
        int index2 = index1 + 1;
        hasSlash = false;
        while (index2 < userInput.Length)
        {
            if (userInput[index2] == '/')
            {
                hasSlash = true;
                break;
            }
            index2 = index2 + 1;
        }
        /*print("Length: " + userInput.Length);
        print(index1);
        print(index2);
        print("First part: " + userInput.Substring(4, index1 - 4));
        print("Second part: " + userInput.Substring(index1 + 1, index2 - index1 + 1));
        print("Second index: " + index1 + 1);
        print("Third part: " + userInput.Substring(index2 + 1, userInput.Length - index2 - 1));
        print("Third index: " + index2 + 1);*/
        if (hasSlash == false || checkLetters(userInput.Substring(4, index1 - 4)) == false || checkNumbers(userInput.Substring(index1 + 1, index2 - index1 - 1)) == false || checkLetters(userInput.Substring(index2 + 1, userInput.Length - index2 - 1)) == false)
            return false;
        return true;
    }

}
