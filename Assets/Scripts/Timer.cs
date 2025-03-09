using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    //Temps actuel
    public float currentTime;
    // Pour gérer si le temps augmente ou diminue
    public bool countDown;

    [Header("Limit Settings")]
    public float timerLimit;

    // Pour arrêter le timer
    public bool timeStop;

    public bool timeOut;


    private void Start()
    {
        // Sécurité pour commencer avec la bonne valeur
        timeStop = false;
        timeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        TimeRun();
    }

    public void TimeRun()
    {
        // Peut tourner tant que le bool est faux
        if (timeStop == false)
        {
            // un else/if écrit un peu différement (si bool vrai - temps, sinon + temps)
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        }

        if (((countDown && currentTime <= timerLimit)))
        {
            // Quand le timer arrive à 0 (ou autre valeur limite)
            currentTime = timerLimit;
            timeOut = true;
            // Désactiver la lecture du composant
            enabled = false;
        }
    }
}
