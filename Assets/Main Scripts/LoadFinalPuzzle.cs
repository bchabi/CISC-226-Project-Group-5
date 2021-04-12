using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinalPuzzle : MonoBehaviour
{
    public string scene;

    public GameObject[] gameObjects;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            
            if (SceneManager.GetSceneAt(0).name != "Computer 6")
                SceneManager.LoadScene(scene);
            else
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    
                    gameObjects[i].gameObject.SetActive(false);
                }
                //GameObject.FindWithTag("Computer 6 Tag").SetActive(true);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Computer 6"));
                //SceneManager.UnloadScene(SceneManager.GetSceneAt(1));
                print(SceneManager.GetActiveScene().GetRootGameObjects()[1].gameObject.name);
                SceneManager.GetActiveScene().GetRootGameObjects()[1].gameObject.SetActive(true);
                //SceneManager.GetActiveScene().GetRootGameObjects()[1].gameObject.
                //GameObject.FindGameObjectWithTag("Computer 6 Tag").SetActive(true);
                print("Active Scene: " + SceneManager.GetActiveScene().name);
                //print("Object with tag: " + GameObject.FindWithTag("Computer 6 Tag").name);
                //GameObject.FindWithTag("Computer 6 Tag").SetActive(true);
            }
        }
    }
}
