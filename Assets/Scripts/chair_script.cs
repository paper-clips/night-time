using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair_script : MonoBehaviour
{
    public Camera cam;
    public GameObject chairLeverDefault;
    public GameObject chairLeverRaised;
    public GameObject chairLeverLowered;
    public GameObject chair0;   
    public GameObject chair1;
    public GameObject chair2;
    public GameObject chair3;
    public GameObject chair4;
    public GameObject chair5;
    public GameObject chair_1;
    public GameObject chair_2;
    public GameObject chair_3;
    public GameObject chair_4;
    public GameObject chair_5;
    public AudioSource chairSqueak;     // Audio Source: https://pixabay.com/sound-effects/chair-squeak-38474/
    float currMouseY;
    bool isLeverHeld;
    bool wasLeverClicked;
    GameObject[] chair;
    GameObject[] lever;
    int chairNum;
    Vector3 leverPos;
    bool isDialogueBoxShowing;

    // Start is called before the first frame update
    void Start()
    {
        currMouseY = 0f;
        isLeverHeld = false;
        wasLeverClicked = false;
        isDialogueBoxShowing = false;

        // Store each chair frame
        chair = new GameObject[11];
        chair[0] = chair_5;
        chair[1] = chair_4;
        chair[2] = chair_3;
        chair[3] = chair_2;
        chair[4] = chair_1;
        chair[5] = chair0;
        chair[6] = chair1;
        chair[7] = chair2;
        chair[8] = chair3;
        chair[9] = chair4;
        chair[10] = chair5;
        chairNum = 5;

        // Store each chair lever frame
        lever = new GameObject[3];
        lever[0] = chairLeverLowered;
        lever[1] = chairLeverDefault;
        lever[2] = chairLeverRaised;
        leverPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // If user clicks anywhere, hide dialogue box
        if (isDialogueBoxShowing && Input.GetMouseButtonDown(0))
        {
            HelperFunctions.updateDialogueBox("", false);
            isDialogueBoxShowing = false;
        }

        // User clicked on chair lever and is holding mouse down
        if (didUserClick2DObject("chair-lever-default", cam))
        {
            currMouseY = Input.mousePosition.y;
            isLeverHeld = true;
            wasLeverClicked = true;
        }

        // User no longer holding mouse down
        if (wasLeverClicked && Input.GetMouseButtonUp(0))
        {
            isLeverHeld = false;
            wasLeverClicked = false;

            // Set chair lever to default state
            HelperFunctions.isInFrame(chairLeverDefault, true);
            HelperFunctions.isInFrame(chairLeverLowered, false);
            HelperFunctions.isInFrame(chairLeverRaised, false);
            chairLeverDefault.transform.localPosition = new Vector3(0, leverPos.y, 0);
        }

        // Lever is being held
        if (isLeverHeld && Input.GetMouseButton(0))
        {
            // Lever pulled up
            if (Input.mousePosition.y > currMouseY && chairNum + 1 < chair.Length)
            {
                chairSqueak.Play();     // Play chair squeak audio

                // Put raised chair in frame and remove current chair from frame
                HelperFunctions.isInFrame(chair[chairNum], false);
                chairNum++;
                HelperFunctions.isInFrame(chair[chairNum], true);

                // Put raised lever in frame and remove current lever from frame
                HelperFunctions.isInFrame(chairLeverDefault, false);
                HelperFunctions.isInFrame(chairLeverRaised, true);

                // Raise the position of the lever
                leverPos.y = leverPos.y + 0.01f;
                chairLeverRaised.transform.localPosition = new Vector3(0, leverPos.y, 0);

                isLeverHeld = false;
            }
            // Lever pulled down
            else if (Input.mousePosition.y < currMouseY && chairNum - 1 >= 0)
            {
                chairSqueak.Play();     // Play chair squeak audio

                // Put lowered chair in frame and remove current chair from frame
                HelperFunctions.isInFrame(chair[chairNum], false);
                chairNum--;
                HelperFunctions.isInFrame(chair[chairNum], true);

                // Put raised lever in frame and remove current lever from frame
                HelperFunctions.isInFrame(chairLeverDefault, false);
                HelperFunctions.isInFrame(chairLeverLowered, true);

                // Lower the position of the lever
                leverPos.y = leverPos.y - 0.01f;
                chairLeverLowered.transform.localPosition = new Vector3(0, leverPos.y, 0);

                isLeverHeld = false;
            }

            // Can't raise chair anymore
            if (chairNum == 10 && Input.mousePosition.y > currMouseY)
            {
                isDialogueBoxShowing = true;
                HelperFunctions.updateDialogueBox("Chair cannot be raised anymore", true);
            }
            // Can't lower chair anymore
            else if (chairNum == 0 && Input.mousePosition.y < currMouseY)
            {
                isDialogueBoxShowing = true;
                HelperFunctions.updateDialogueBox("Chair cannot be lowered anymore", true);
            }
        }
    }

    // Detect whether user clicked on specific object (Works on objects with 2D colliders)
    bool didUserClick2DObject(string objectName, Camera cam)
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Reference used: "https://www.codegrepper.com/tpc/how+to+make+a+sprite+detect+clicked+in+unity+2d"
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            //------------------------------------------------------------------------------------------------//

            // User clicked on something
            if (hit.collider != null)
            {
                // If clicked specified object
                if (hit.collider.gameObject.name == objectName)
                {
                    Debug.Log("User clicked " + hit.transform.name);
                    return true;
                }
            }
        }
        return false;
    }
}
