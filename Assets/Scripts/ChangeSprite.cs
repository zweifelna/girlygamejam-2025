using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public CatController cat;

    public Sprite interestedCat;
    public Sprite boredCat;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = interestedCat;
    }

    // Update is called once per frame
    void Update()
    {
        if(cat.currentState == CatController.CatState.Bored)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = boredCat;
        }else if (cat.currentState == CatController.CatState.Interested){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = interestedCat;
        }
    }
}
