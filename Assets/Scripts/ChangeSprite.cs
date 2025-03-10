using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public CatController cat;

    public Sprite interestedCat;
    public Sprite boredCat;

    public Animator animationsCat;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = interestedCat;
        animationsCat = GetComponent<Animator>();
        animationsCat.Play("cat_bored_still");
    }

    // Update is called once per frame
    void Update()
    {
        if (cat.currentState == CatController.CatState.Bored)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = boredCat;
            animationsCat.Play("cat_bored_still");

        }
        else if (cat.currentState == CatController.CatState.Interested)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = interestedCat;
            animationsCat.Play("cat_walking");
        }
    }
}
