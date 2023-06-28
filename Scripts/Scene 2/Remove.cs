using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour // added to the instantiate food
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((GameFlow2.emptyPlateNow > transform.position.x - .4f) && (GameFlow2.emptyPlateNow < transform.position.x + .4f)) //if empty plate between the condition (.4f), then delete the food
        {
            Destroy(gameObject);
        }
    }

    public void DestroyFood()
    {
        if ((GameFlow2.emptyPlateNow > transform.position.x - .4f) && (GameFlow2.emptyPlateNow < transform.position.x + .4f))
        {
            Destroy(gameObject);
        }
    }
}
