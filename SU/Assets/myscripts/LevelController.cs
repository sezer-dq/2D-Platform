using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public AudioSource theme;
   public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void settingsMenu()
    {
        SceneManager.LoadScene(4);
    }
    public void setquality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }
    public void fullScreen(bool isfull)
    {
        Screen.fullScreen = isfull;
    }
    public void sound(bool vol)
    {
        theme.mute = !vol;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(0);
        }
    }
}
