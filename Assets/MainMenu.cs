using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadSceneAsync("Main_Game");
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
