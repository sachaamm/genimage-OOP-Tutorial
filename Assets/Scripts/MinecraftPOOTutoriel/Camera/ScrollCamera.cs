using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script permettant de scroller la camera
public class ScrollCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.magnitude > 0)
        {
            transform.Translate(new Vector3(0,0, Input.mouseScrollDelta.y));
        }
    }
}
