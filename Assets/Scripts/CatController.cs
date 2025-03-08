using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CatController : MonoBehaviour
{
    private enum CatState { Neutral, Interested, Bored } // États du chat
    private CatState currentState = CatState.Neutral;    // État actuel

    private Vector2 catPosition;
    public Vector2 catSpeed = new Vector2(-1, 0);

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
            case CatState.Neutral:
                if (Input.GetKey(KeyCode.A))
                {
                    Debug.Log("Chat devient intéressé !");
                    currentState = CatState.Interested;
                    // Calcul la distance pour ce round
                    distanceWalk = Random.Range(1.0f, 3.0f);
                    Debug.Log(distanceWalk);
                }
                break;

            case CatState.Interested:
                if (Input.GetKey(KeyCode.A) && (catWalking <= distanceWalk)) // Le chat avance tant que la valeur de distanceWalk n'est pas atteinte
                {
                    catPosition += catSpeed; // Déplacement
                    // Se base sur la vitesse de déplacement du chat
                    catWalking -= catSpeed.x / 2;
                    Debug.Log(catWalking);

                }
                else
                {
                    Debug.Log("Chat se lasse...");
                    currentState = CatState.Bored;
                }
                break;

            case CatState.Bored:
                if (Input.GetKey(KeyCode.A))
                {
                    Debug.Log("Chat reprend de l'intérêt !");
                    currentState = CatState.Interested;
                }
                break;
        }
    }
}
