using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragItems_script : MonoBehaviour
{
    public Camera cam;
    public GameObject plant;
    public GameObject bag;
    public Collider2D floor;
    public Collider2D table;
    GameObject heldObject;
    bool isUserHoldingObject;
    //int heldObjectOrder;

    // Start is called before the first frame update
    void Start()
    {
        isUserHoldingObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If not holding object yet, but clicked on object
        if (!isUserHoldingObject && didUserClick2DObject("plant", cam))
        {
            isUserHoldingObject = true;
            heldObject = plant;
            //heldObjectOrder = plant.GetComponent<SpriteRenderer>().sortingOrder;
        }
        /*else if (!isUserHoldingObject && didUserClick2DObject("Bag", cam))
        {
            isUserHoldingObject = true;
            heldObject = bag;
            //heldObjectOrder = bag.GetComponent<SpriteRenderer>().sortingOrder;
        }*/

        // Drag item while user holding onto it
        if (isUserHoldingObject)
        {
            dragItem(heldObject);
        }

        // Let go of object
        if (isUserHoldingObject && Input.GetMouseButtonUp(0))
        {
            isUserHoldingObject = false;
            //heldObject.GetComponent<SpriteRenderer>().sortingOrder = heldObjectOrder;

            // If object is not touching tabe or floor, palce it back to original position
            if (!table.bounds.Intersects(heldObject.GetComponent<Collider2D>().bounds) && !floor.bounds.Intersects(heldObject.GetComponent<Collider2D>().bounds))
            {
                heldObject.transform.position = new Vector3(0, 0, 0);
            }
        }
    }

    void dragItem(GameObject heldObject)
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        heldObject.transform.position = new Vector3(pos.x + 0.3f, pos.y + 0.25f, 0);
        //heldObject.GetComponent<SpriteRenderer>().sortingOrder = 30;

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
                // If user clicked on any object
                if (objectName == "anyObject")
                {
                    Debug.Log("User clicked something");
                    return true;
                }
                // If clicked specified object
                else if (hit.collider.gameObject.name == objectName)
                {
                    Debug.Log("User clicked " + hit.transform.name);
                    return true;
                }
            }
        }
        return false;
    }
}
