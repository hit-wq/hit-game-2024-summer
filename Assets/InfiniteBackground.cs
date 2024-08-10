using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public GameObject another_background;
    // Start is called before the first frame update
    Vector2 another_start_position;
    Vector2 this_start_position;

    Vector2 distance;
    void Start()
    {
        another_start_position = another_background.transform.position;
        this_start_position=transform.position;
     
        distance=another_start_position-this_start_position;
        //Debug.Log($"left: ({this_start_position.x}, {this_start_position.y}£¬{distance.x})");
    }
 

    // Update is called once per frame
   
    void Update()
    {

        transform.Translate(new Vector2(-10, 0) * Time.deltaTime);
        if(another_background.transform.position.x < this_start_position.x && another_background.transform.position.x>transform.position.x)
        {
            transform.Translate(2*distance);
           // Debug.Log("×ó²à±³¾°ÓÒÒÆ");
        }
       
    }
}
