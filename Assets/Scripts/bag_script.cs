using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag_script : MonoBehaviour
{
    public Camera cam;
    public GameObject bag_opened;
    public GameObject bag_closed;
    public AudioSource bagOpenSound;        // Audio source: https://pixabay.com/sound-effects/zipper-85686/
    public AudioSource bagCloseSound;
    bool isBagOpened;

    // Start is called before the first frame update
    void Start()
    {
        isBagOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if user clicked on bag
        bool isBagOpenedClicked = HelperFunctions.didUserClick2DObject("bag_opened", cam);
        bool isBagClosedClicked = HelperFunctions.didUserClick2DObject("bag_closed", cam);

        // Open or close the bag
        if (isBagClosedClicked || isBagOpenedClicked)
            updateBag();
    }

    // Open or close bag when user clicks on the bag
    void updateBag()
    {
        // Close bag
        if (isBagOpened == true)
        {
            bagCloseSound.Play();
            HelperFunctions.isInFrame(bag_opened, false);
            HelperFunctions.isInFrame(bag_closed, true);
            isBagOpened = false;
        }
        // Open bag
        else
        {
            bagOpenSound.Play();
            HelperFunctions.isInFrame(bag_opened, true);
            HelperFunctions.isInFrame(bag_closed, false);
            isBagOpened = true;
        }
    }
}
