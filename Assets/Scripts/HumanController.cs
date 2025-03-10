using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HumanController : MonoBehaviour
{
    public enum HumanState { Neutral, Pstpst, Catch } // États de l'humain
    public HumanState currentState = HumanState.Neutral;    // État actuel

    public AudioManager audioManager;

    public Vector2 humanPosition;

    public Boolean isTrigger = false;

    private bool isPstpstPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        this.humanPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleState(); // Gère l'état actuel du chat
    }

    private void HandleState()
    {
        switch (currentState)
        {
            case HumanState.Neutral:
                if (Input.GetKey(KeyCode.A))
                {
                    currentState = HumanState.Pstpst;
                    //Debug.Log("Neutre");
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    currentState = HumanState.Catch;
                    //Debug.Log("Catch");
                }
                break;

            case HumanState.Pstpst:
                if (Input.GetKey(KeyCode.A)) // Joue le son une seule fois au début
                {
                    Debug.Log("isPLaying?"+isPstpstPlaying);
                    if (!isPstpstPlaying)
                    {
                        Debug.Log("play psspss");
                        audioManager.Play("Psspss");
                        isPstpstPlaying = true;
                    }
                } if (Input.GetKeyUp(KeyCode.A)) // Arrête le son lorsqu'on relâche la touche
                {
                    audioManager.Stop("Psspss");
                    isPstpstPlaying = false;
                    currentState = HumanState.Neutral;
                }
                break;

            case HumanState.Catch:
                if (Input.GetKey(KeyCode.D))
                {
                    //Debug.Log("Catching");

                }
                else if (Input.GetKeyUp(KeyCode.D))
                {
                    currentState = HumanState.Neutral;
                    //Debug.Log("Go neutre");
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HUMAN");
        // Pour déterminer si on peut attraper ou non le chat
        isTrigger = true;
    }

    
}
