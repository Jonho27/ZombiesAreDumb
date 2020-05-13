using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public static bool audioOn;

    public void Start()
    {

    }

    private void Update()
    {

    }

    public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }    public void Options()
    {
        SceneManager.LoadScene("Options");
    }    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }    public void Intro()
    {
        SceneManager.LoadScene("Intro");
    }
}
