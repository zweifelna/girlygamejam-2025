using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteHuman : MonoBehaviour
{

    public HumanController human;

    public Animator animationsHuman;

    // Start is called before the first frame update
    void Start()
    {
        animationsHuman = GetComponent<Animator>();
        animationsHuman.Play("bras_neutre_still");
    }

    // Update is called once per frame
    void Update()
    {
        if (human.currentState == HumanController.HumanState.Pstpst)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = boredCat;
            animationsHuman.Play("bras_pstpst");

        }
        else if (human.currentState == HumanController.HumanState.Catch)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = interestedCat;
            animationsHuman.Play("bras_try_catch");
        }
        else
        {
            animationsHuman.Play("bras_neutre_still");
        }

    }
}
