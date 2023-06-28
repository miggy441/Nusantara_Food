using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removefood : MonoBehaviour // added to the instantiate food
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameFlow.emptyPlateNow > transform.position.x-.4f) && (gameFlow.emptyPlateNow < transform.position.x + .4f)) //if empty plate between the condition (.4f), then delete the food
        {
            Destroy(gameObject);
        }
    }
}
