using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // End game if user clicks Escape button
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
