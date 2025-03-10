using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicController : MonoBehaviour
{

    public HumanController human;
    public CatController cat;
    public AudioManager audioManager;
    public GameObject retryButton;

    public GameObject humanObject;
    public GameObject catObject;
    public GameObject winScreen;


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
            ShowWinScreen();
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

    void ShowWinScreen()
    {
        // Désactive le chat et l'humain
        humanObject.SetActive(false);
        catObject.SetActive(false);

        // Active l'écran de victoire
        winScreen.SetActive(true);

        // Affiche le bouton Retry
        retryButton.SetActive(true);
    }
}
