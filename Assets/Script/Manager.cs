using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public bool isGameEndStarted;
    LineFactory lineFactory;
    //public GameObject GameEndCanvas;
    public TMPro.TextMeshProUGUI StarText;
    public int StarCount;
    public bool gameCleared;
    public GameObject LoadNextLevelButton;
    public int LoadAfterSec;
    public int currentScence;
    

    // Start is called before the first frame update
    void Start()
    {
        //GameEndCanvas.SetActive(false);
        lineFactory = FindObjectOfType<LineFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lineFactory.isRunning && !isGameEndStarted)
        {
            //Invoke("StartEndScreed", 2f);
            isGameEndStarted = true;
        }
    }

    /*public void StartEndScreed()
    {
        GameEndCanvas.SetActive(true);
        if (!gameCleared)
        {
            LoadNextLevelButton.SetActive(false);
        }
    }*/

    public void LoadNextScene()
    {
        FindObjectOfType<LeveSceneManager>().LoadScene(currentScence + 1);
    }

    public void RestartScene()
    {
        FindObjectOfType<LeveSceneManager>().LoadScene(currentScence);
    }
}
