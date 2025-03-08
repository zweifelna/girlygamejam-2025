using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Garde le GameManager entre les scènes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene"); // Charge la scène du jeu
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene"); // Charge le menu
    }

    public void QuitGame()
    {
        Application.Quit(); // Quitte le jeu (ne fonctionne que dans une build)
    }
}

