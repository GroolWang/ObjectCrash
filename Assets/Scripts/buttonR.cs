using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonR : Button
{
    // Update is called once per frame
    void Update()
    {
        if (IsPressed())
        {
            GameObject go = GameObject.FindGameObjectWithTag("currentObject");
            go.transform.Rotate(Vector3.forward * 3);
        }
        
    }
}
