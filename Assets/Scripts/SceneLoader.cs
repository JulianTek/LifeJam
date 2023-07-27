using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EventSystem;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        EventChannels.PlayerEvents.OnGameOver += GameOver;
    }

    private void OnDestroy()
    {
        EventChannels.PlayerEvents.OnGameOver -= GameOver;
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    void GameOver()
    {
        LoadScene(3);
    }
}
