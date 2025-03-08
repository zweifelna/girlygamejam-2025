using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        playButton.onClick.AddListener(() => GameManager.Instance.LoadGame());
        quitButton.onClick.AddListener(() => GameManager.Instance.QuitGame());
    }
}

