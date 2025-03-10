using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CatController : MonoBehaviour
{
    public enum CatState { Neutral, Interested, Bored } // États du chat
    public CatState currentState = CatState.Bored;    // État actuel

    public Vector2 catPosition;
    Vector3 startPos;
    public Vector2 catSpeed = new Vector2(-1, 0);

    public HumanController human;

    public Timer time;


    // "Distance" parcourue par le chat et calculée aléatoirement
    float distanceWalk;
    // Le temps que le chat mettra à atteindre cette distance
    float catWalking;

    void Start()
    {
        Debug.Log(currentState);
        currentState = CatState.Bored;
        Debug.Log(currentState);
        this.catPosition = this.transform.position;
        startPos = transform.position;
        StartCoroutine(WaitRandomSeconds());
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
            // case CatState.Neutral:
            //     if (time.currentTime > 0)
            //     {
            //         //Debug.Log("Chat devient intéressé !");
            //         //currentState = CatState.Interested;
            //         // Calcul la distance pour ce round
            //         //distanceWalk = Random.Range(1.0f, 3.0f);
            //         //Debug.Log("Distance à parcourir init :" + distanceWalk);
            //         //catWalking = 0;
            //         Debug.Log("Timer tourne");
            //     }
            //     else
            //     {
            //         currentState = CatState.Bored;
            //         time.enabled = true;
            //         time.timeOut = false;
            //         Debug.Log("Timeout");
            //     }
            //     break;

            case CatState.Interested:
                if (human.currentState == HumanController.HumanState.Pstpst && (catWalking <= distanceWalk) && !human.isTrigger) // Le chat avance tant que la valeur de distanceWalk n'est pas atteinte
                {
                    //Debug.Log("Hello");
                    catPosition += catSpeed; // Déplacement
                    // Se base sur la vitesse de déplacement du chat
                    //catWalking -= catSpeed.x / 2; // à tester à la fin: * Time.deltaTime
                    //Debug.Log("Le chat a parcouru :" + catWalking);
                    //Debug.Log("Chat intéressé");

                }
                // else
                // {
                //     //Debug.Log("Chat se lasse...");
                //     currentState = CatState.Bored;
                // }
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
                    //Debug.Log("Chat ennuyé");
                }
                break;
        }
    }


    IEnumerator WaitRandomSeconds()
    {
        while (true)
        {
            //Print the time of when the function is first called.
            //Debug.Log("Started Coroutine at timestamp : " + Time.time);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));

            if (currentState == CatState.Interested)
            {
                //Debug.Log("in interested if");
                currentState = CatState.Bored;
            }
            else if (currentState == CatState.Bored && !human.isTrigger)
            {
                if (human.currentState == HumanController.HumanState.Pstpst) currentState = CatState.Interested;
            }
            else if (currentState == CatState.Bored && human.isTrigger)
            {
                //Debug.Log("in bored if");
                currentState = CatState.Interested;
            }
            Debug.Log(currentState);

            //After we have waited 5 seconds print the time again.
            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }
    }

    public void DodgeAndReset()
    {
        StartCoroutine(DodgeCoroutine());
    }

    private IEnumerator DodgeCoroutine()
    {
        Vector3 dodgeTarget = startPos + new Vector3(2f, 2f, 0f);
        Vector3 resetPosition = new Vector3(startPos.x, startPos.y, startPos.z); // Position initiale à droite

        float duration = 0.3f;
        float resetDuration = 1f;

        // Monte en diagonale
        float elapsed = 0;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, dodgeTarget, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Redescend
        elapsed = 0;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(dodgeTarget, startPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Retourne à la position initiale
        elapsed = 0;
        while (elapsed < resetDuration)
        {
            transform.position = Vector3.Lerp(startPos, resetPosition, elapsed / resetDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        catPosition = resetPosition;
    }

}


