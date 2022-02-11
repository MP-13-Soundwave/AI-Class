using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    /*create variable   
    place data in variable
    use variable*/
    public GameObject position0;
    public GameObject position1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.x < position0.transform.position.x)
        {
            //move right
            Vector2 AIPostion = transform.position;
            AIPostion.x += (1 * Time.deltaTime);
            transform.position = AIPostion;
        }
        else 
        {
            //move left
            Vector2 AIPostion = transform.position;
            AIPostion.x -= (1 * Time.deltaTime);
            transform.position = AIPostion;
        }
        //Vector2 directionToPos0 = (Vector2)(position0.transform.position - transform.position);
    }


}
