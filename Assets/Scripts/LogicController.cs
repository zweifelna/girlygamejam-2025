using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicController : MonoBehaviour
{

    public HumanController human;
    public CatController cat;
    public AudioManager audioManager;
    public GameObject retryButton;


    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (human.isTrigger == true && cat.currentState == CatController.CatState.Bored && human.currentState == HumanController.HumanState.Catch)
        {
            // On peut attraper le chat
            Debug.Log("HAAAAAAA");
            audioManager.Play("CuteCat");
            ShowRetryButton();
        }
        else if (human.isTrigger == true && cat.currentState == CatController.CatState.Interested && human.currentState == HumanController.HumanState.Catch)
        {
            Debug.Log("Dodge");
            cat.DodgeAndReset();
            audioManager.Play("AngryCat");
            human.isTrigger = false;
        }
    }

    void ShowRetryButton()
    {
        retryButton.SetActive(true); // Affiche le bouton quand on attrape le chat
    }

    public void RestartGame()
    {
        retryButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène
    }
}
