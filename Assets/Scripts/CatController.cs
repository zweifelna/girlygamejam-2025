using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CatController : MonoBehaviour
{
    public enum CatState { Neutral, Interested, Bored } // États du chat
    public CatState currentState = CatState.Neutral;    // État actuel

    public Vector2 catPosition;
    public Vector2 catSpeed = new Vector2(-1, 0);

    public HumanController human;

    public Timer time;


    // "Distance" parcourue par le chat et calculée aléatoirement
    float distanceWalk;
    // Le temps que le chat mettra à atteindre cette distance
    float catWalking;

    void Start()
    {
        this.catPosition = this.transform.position;
    }

    void Update()
    {
        this.transform.position = catPosition; // Met à jour la position du chat

        HandleState(); // Gère l'état actuel du chat
    }

    private void HandleState()
    {
        switch (currentState)
        {
            // Pas utile pour la version finale
            case CatState.Neutral:
                if (time.currentTime > 0)
                {
                    //Debug.Log("Chat devient intéressé !");
                    //currentState = CatState.Interested;
                    // Calcul la distance pour ce round
                    //distanceWalk = Random.Range(1.0f, 3.0f);
                    //Debug.Log("Distance à parcourir init :" + distanceWalk);
                    //catWalking = 0;
                    Debug.Log("Timer tourne");
                }
                else
                {
                    currentState = CatState.Bored;
                    time.enabled = true;
                    time.timeOut = false;
                    Debug.Log("Timeout");
                }
                break;

            case CatState.Interested:
                if (human.currentState == HumanController.HumanState.Pstpst && (catWalking <= distanceWalk) && !human.isTrigger) // Le chat avance tant que la valeur de distanceWalk n'est pas atteinte
                {
                    //Debug.Log("Hello");
                    catPosition += catSpeed; // Déplacement
                    // Se base sur la vitesse de déplacement du chat
                    catWalking -= catSpeed.x / 2; // à tester à la fin: * Time.deltaTime
                    Debug.Log("Le chat a parcouru :" + catWalking);

                }
                else
                {
                    //Debug.Log("Chat se lasse...");
                    currentState = CatState.Bored;
                }
                break;

            case CatState.Bored:
                if (Input.GetKeyDown(KeyCode.A)) // Trouver comment obliger la personne à ne pas cliquer sur A sans que cela créer de conflit avec le reste des states
                {
                    time.currentTime = 10;
                    //Debug.Log("Chat reprend de l'intérêt !");
                    //currentState = CatState.Interested;
                    // Calcul la distance pour ce round
                    //distanceWalk = Random.Range(1.0f, 3.0f);
                    //Debug.Log("Distance à parcourir :" + distanceWalk);
                    //catWalking = 0;
                }
                break;
        }
    }
}
