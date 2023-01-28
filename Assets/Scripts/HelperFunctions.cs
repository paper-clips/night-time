using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    // Move the sprite in or out of camera
    public static void isInFrame(GameObject obj, bool inFrame)
    {
        if (inFrame == true)
            obj.transform.position = new Vector3(0, 0, 0);     // In frame
        else
            obj.transform.position = new Vector3(0, -3, 0);    // Out of frame
    }

    // Move the sprite in or out of camera (with specific position)
    public static void isInFrame(GameObject obj, bool inFrame, float xPos, float yPos, float zPos)
    {
        if (inFrame == true)
            obj.transform.position = new Vector3(xPos, yPos, zPos);     // In frame
        else
            obj.transform.position = new Vector3(0, -3, 0);    // Out of frame
    }

    // Detect whether user clicked on specific object (Works on objects with 2D colliders)
    public static bool didUserClick2DObject(string objectName, Camera cam)
    {
        if (Input.GetMouseButtonUp(0))
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

    // Detect whether user clicked on specific object
    public static bool didUserClickObject(string objectName, Camera cam)
    {
        // If user clicks left mouse button
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // If clicked specified object
                if (hit.transform.name == objectName)
                {
                    Debug.Log("User clicked " + hit.transform.name);
                    return true;
                }
            }
        }
        return false;
    }

    // Change text of dialogue box
    public static void changeDialogueText(string input)
    {
        UnityEngine.UI.Text text = GameObject.Find("Dialogue").GetComponent<dialogue_script>().Text;
        text.text = input;
    }
}
