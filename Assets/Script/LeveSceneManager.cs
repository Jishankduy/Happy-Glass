using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveSceneManager : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadScene(int sceneNo = 0)
    {
        SceneManager.LoadScene(sceneNo);
    }
}
