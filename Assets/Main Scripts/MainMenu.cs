using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
    public GameObject SettingsPanel;
   
	public void startGame()
	{

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }
    public void SettingsExit()
    {
        SettingsPanel.SetActive(false);
    }
    public void exitGame()
	{
		Application.Quit ();
	}
	
	public void LowQuality()
	{
		QualitySettings.SetQualityLevel (0,true);
	}
	public void MediumQuality()
	{
		QualitySettings.SetQualityLevel (2,true);
	}
	public void HighQuality()
	{
		QualitySettings.SetQualityLevel (4,true);
	}
    public void UltraQuality()
    {
        QualitySettings.SetQualityLevel (6, true);
    }
}