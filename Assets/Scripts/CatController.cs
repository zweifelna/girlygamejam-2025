using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private enum CatState { Neutral, Interested, Bored } // États du chat
    private CatState currentState = CatState.Neutral;    // État actuel

    private Vector2 catPosition;
    public Vector2 catSpeed = new Vector2(-1, 0);

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
                }
                break;

            case CatState.Interested:
                if (Input.GetKey(KeyCode.A))
                {
                    catPosition += catSpeed; // Déplacement
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
