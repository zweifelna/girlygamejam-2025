using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HumanController : MonoBehaviour
{
    public enum HumanState { Neutral, Pstpst, Catch } // États de l'humain
    public HumanState currentState = HumanState.Neutral;    // État actuel


    public Vector2 humanPosition;

    public Boolean isTrigger = false;

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
                if (Input.GetKey(KeyCode.A))
                {
                    //Debug.Log("Pstpst");
                }
                else if (Input.GetKeyUp(KeyCode.A))
                {
                    currentState = HumanState.Neutral;
                    //Debug.Log("Go neutre");
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
