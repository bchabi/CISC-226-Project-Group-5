using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloakDurability : MonoBehaviour
{
    public PlayerMovement canStillCloak;
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;
    public bool canCountdown;
    public GameObject Map;
   

    public void Start()
    {
        canCountdown = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;

    }

    public void Update()
    {

        if (canCountdown)
        {
            gameTime -= Time.deltaTime;
            timerSlider.value = gameTime;
            if (gameTime <= 0)
            {
                
                canCountdown = false;
                gameTime = 3;
                timerSlider.value = gameTime;
            }
        }
        



    }

    public void openMap()
    {

        if (!Map.activeSelf)
        {
            Map.SetActive(true);
        }
        else if (Map.activeSelf)
        {
            Map.SetActive(false);
        }
        
    }
}