using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{

    public HumanController human;
    public CatController cat;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (human.isTrigger == true && cat.currentState == CatController.CatState.Bored && human.currentState == HumanController.HumanState.Catch)
        {
            // On peut attraper le chat
            Debug.Log("HAAAAAAA");
        }
        else if (human.isTrigger == true && cat.currentState == CatController.CatState.Interested && human.currentState == HumanController.HumanState.Catch)
        {
            Debug.Log("Dodge");
            cat.DodgeAndReset();
            human.isTrigger = false;
        }
    }
}
