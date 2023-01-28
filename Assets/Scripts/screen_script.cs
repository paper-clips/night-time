using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen_script : MonoBehaviour
{
    public Camera cam;
    public GameObject Drawers;
    public GameObject Screen_closedDrawers;
    public GameObject Screen_off;
    public GameObject Screen_0;
    public GameObject Screen_1;
    public GameObject Screen_2;
    public GameObject Screen_3;
    bool isScreenOn;
    bool isDrawer0Opened;
    bool isDrawer1Opened;
    bool isDrawer2Opened;
    bool isDrawer3Opened;
    bool isDrawerLightingOn;

    // Start is called before the first frame update
    void Start()
    {
        isScreenOn = false;
        isDrawer0Opened = false;
        isDrawer1Opened = false;
        isDrawer2Opened = false;
        isDrawer3Opened = false;
        isDrawerLightingOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        isDrawer0Opened = Drawers.GetComponent<drawers_script>().isDrawer0Opened;
        isDrawer1Opened = Drawers.GetComponent<drawers_script>().isDrawer1Opened;
        isDrawer2Opened = Drawers.GetComponent<drawers_script>().isDrawer2Opened;
        isDrawer3Opened = Drawers.GetComponent<drawers_script>().isDrawer3Opened;

        if (HelperFunctions.didUserClickObject("screen_off", cam) || HelperFunctions.didUserClickObject("screen_closedDrawers", cam) || HelperFunctions.didUserClickObject("screen_0", cam) || HelperFunctions.didUserClickObject("screen_1", cam) || HelperFunctions.didUserClickObject("screen_2", cam) || HelperFunctions.didUserClickObject("screen_3", cam))
        {
            // Turn off screen
            if (isScreenOn)
            {
                Debug.Log("0");
                HelperFunctions.isInFrame(Screen_closedDrawers, false);
                HelperFunctions.isInFrame(Screen_off, true, 0, -0.06012f, 0);
                HelperFunctions.isInFrame(Screen_0, false);
                HelperFunctions.isInFrame(Screen_1, false);
                HelperFunctions.isInFrame(Screen_2, false);
                HelperFunctions.isInFrame(Screen_3, false);
                isScreenOn = false;
                isDrawerLightingOn = false;
            }
            else 
            {
                isDrawerLightingOn = true;
            }
        }

        if (isDrawerLightingOn)
        {
            HelperFunctions.isInFrame(Screen_off, false);

            // Turn on screen
            if (!isDrawer0Opened && !isDrawer1Opened && !isDrawer2Opened && !isDrawer3Opened)
            {
                Debug.Log("1");
                HelperFunctions.isInFrame(Screen_closedDrawers, true);
                HelperFunctions.isInFrame(Screen_off, false);
                HelperFunctions.isInFrame(Screen_0, false);
                HelperFunctions.isInFrame(Screen_1, false);
                HelperFunctions.isInFrame(Screen_2, false);
                HelperFunctions.isInFrame(Screen_3, false);
            }
            else
            {
                HelperFunctions.isInFrame(Screen_closedDrawers, false);
            }
            
            if (isDrawer0Opened)
            {
                Debug.Log("2");
                HelperFunctions.isInFrame(Screen_0, true);
  
            }
            else
            {
                HelperFunctions.isInFrame(Screen_0, false);
            }

            if (isDrawer1Opened)
            {
                Debug.Log("3");
                HelperFunctions.isInFrame(Screen_1, true);
                HelperFunctions.isInFrame(Screen_2, false);
                HelperFunctions.isInFrame(Screen_3, false);
            }
            else
            {
                HelperFunctions.isInFrame(Screen_1, false);
            }

            if (isDrawer2Opened)
            {
                Debug.Log("4");
                HelperFunctions.isInFrame(Screen_2, true);
                HelperFunctions.isInFrame(Screen_3, false);
            }
            else
            {
                HelperFunctions.isInFrame(Screen_2, false);
            }
            
            if (isDrawer3Opened)
            {
                Debug.Log("5");
                HelperFunctions.isInFrame(Screen_3, true);
            }
            else
            {
                HelperFunctions.isInFrame(Screen_3, false);
            }

            isScreenOn = true;
        }
    }
}
