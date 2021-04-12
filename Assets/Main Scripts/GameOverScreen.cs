using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject UI1;
    public GameObject DialogueBox;
    public void Setup()
    {
        gameObject.SetActive(true);
        UI1.SetActive(false);
        DialogueBox.SetActive(false);
        
    }

    public void RestartButton()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void SpecialRestartButton()
    {
        SceneManager.LoadScene("Cabin_Final_01a");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("HorrorMenu");
    }
}
