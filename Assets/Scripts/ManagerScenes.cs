using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{

    public static ManagerScenes instance;

    private void Awake()
    {
        instance = this;
    }

    
    public void LoadNextScene() // course name: Complete C# Unity Developer 2D - Learn to Code Making Game // doesn't work now??
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        currentSceneIndex++;

        if (currentSceneIndex == SceneManager.sceneCount)
        {
            currentSceneIndex = 0;
        }

        SceneManager.LoadScene(currentSceneIndex);
    }


    public string levelToLoad = "MainScene";

    public SceneFader sceneFader;

    public int levelChosenNumber;
    public static int levelChosenNumberStatic;



    public void Play()
    {
        //SceneManager.LoadScene (levelToLoad);
        sceneFader.FadeTo(levelToLoad);
    }

    public void LevelChosen(int levelChosenNumber)
    {
        levelChosenNumberStatic = levelChosenNumber;
        //Debug.Log(levelChosenNumber);
    }



}
