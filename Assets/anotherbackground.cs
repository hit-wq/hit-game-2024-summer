using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class anotherbackg : MonoBehaviour
{
    public GameObject another_background;
    // Start is called before the first frame update
    Vector2 another_start_position;
    Vector2 this_start_position;
   // Vector2 this_real_position;
    Vector2 distance;
    void Start()
    {
        another_start_position = another_background.transform.position;
        this_start_position = transform.position;
      //  this_real_position = this_start_position;
        distance = another_start_position - this_start_position;
       // Debug.Log($"right: ({this_start_position.x}, {this_start_position.y}£¬{distance.x})");
    }


    // Update is called once per frame

    void Update()
    {

        transform.Translate(new Vector2(-10, 0) * Time.deltaTime );
        if (another_background.transform.position.x < another_start_position.x && transform.position.x < another_background.transform.position.x)
        {
            transform.Translate(- 2 * distance);
          // Debug.Log("ÓÒ²à±³¾°·µ»Øµ½´óÓÒ²à");
        }

    }
}
