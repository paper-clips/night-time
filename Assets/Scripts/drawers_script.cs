using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawers_script : MonoBehaviour
{
    public Camera cam;
    public GameObject drawer0_opened;
    public GameObject drawer1_opened;
    public GameObject drawer2_opened;
    public GameObject drawer3_opened;
    public GameObject drawer0_closed;
    public GameObject drawer1_closed;
    public GameObject drawer2_closed;
    public GameObject drawer3_closed;
    public bool isDrawer0Opened;
    public bool isDrawer1Opened;
    public bool isDrawer2Opened;
    public bool isDrawer3Opened;
    public AudioSource drawerOpenSound;     // Audio source: https://pixabay.com/sound-effects/drawer-41055/
    public AudioSource drawerCloseSound;    // Audio source: https://pixabay.com/sound-effects/close-the-drawer-3-95680/
    public AudioSource cabinetOpenSound;    // Audio source: https://pixabay.com/sound-effects/cabinet-3-106677/
    public AudioSource cabinetCloseSound;    // Audio source: https://pixabay.com/sound-effects/closetclose-42944/

    // Start is called before the first frame update
    void Start()
    {
        isDrawer0Opened = false;
        isDrawer1Opened = false;
        isDrawer2Opened = false;
        isDrawer3Opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Open or close the drawer which the user clicked on
        updateDrawers();
    }

    // Open or close the drawers the user clicks on
    void updateDrawers()
    {
        updateSingleDrawer("drawer0", "drawer0-closed", drawer0_opened, drawer0_closed, 0);
        updateSingleDrawer("drawer1", "drawer1-closed", drawer1_opened, drawer1_closed, 1);
        updateSingleDrawer("drawer2", "drawer2-closed", drawer2_opened, drawer2_closed, 2);
        updateSingleDrawer("drawer3", "drawer3-closed", drawer3_opened, drawer3_closed, 3);
    }

    // Open or close individual drawer
    void updateSingleDrawer(string openedDrawerName, string closedDrawerName, GameObject openedDrawer, GameObject closedDrawer, int drawerNum)
    {
        bool isCurrDrawerOpen = false;
        if (drawerNum == 0)
            isCurrDrawerOpen = isDrawer0Opened;
        else if (drawerNum == 1)
            isCurrDrawerOpen = isDrawer1Opened;
        else if (drawerNum == 2)
            isCurrDrawerOpen = isDrawer2Opened;
        else if (drawerNum == 3)
            isCurrDrawerOpen = isDrawer3Opened;
        else
            Debug.Log("Invalid number.");

        // User clicked on drawer
        bool wasDrawerClosed = HelperFunctions.didUserClick2DObject(closedDrawerName, cam);
        bool wasDrawerOpened = HelperFunctions.didUserClick2DObject(openedDrawerName, cam);
        if (wasDrawerClosed || wasDrawerOpened)
        {
            // Open drawer
            if (isCurrDrawerOpen == false)
            {
                HelperFunctions.isInFrame(openedDrawer, true);
                HelperFunctions.isInFrame(closedDrawer, false);

                // Play drawer/cabinet opening/closing sound
                if (drawerNum != 0)
                    drawerOpenSound.Play();
                else
                    cabinetOpenSound.Play();

                if (drawerNum == 0)
                    isDrawer0Opened = true;
                else if (drawerNum == 1)
                    isDrawer1Opened = true;
                else if (drawerNum == 2)
                    isDrawer2Opened = true;
                else if (drawerNum == 3)
                    isDrawer3Opened = true;
                else
                    Debug.Log("Invalid number.");
            }
            else
            {
                HelperFunctions.isInFrame(openedDrawer, false);
                HelperFunctions.isInFrame(closedDrawer, true);

                // Play drawer/cabinet opening/closing sound
                if (drawerNum != 0)
                    drawerCloseSound.Play();
                else
                    cabinetCloseSound.Play();

                if (drawerNum == 0)
                    isDrawer0Opened = false;
                else if (drawerNum == 1)
                    isDrawer1Opened = false;
                else if (drawerNum == 2)
                    isDrawer2Opened = false;
                else if (drawerNum == 3)
                    isDrawer3Opened = false;
                else
                    Debug.Log("Invalid number.");
            }
        }
    }
}
