using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_script : MonoBehaviour
{
    public GameObject Dialogue;
    public UnityEngine.UI.Text Text;
    bool isDialogueShowing;

    // Start is called before the first frame update
    void Start()
    {
        isDialogueShowing = false;
        HelperFunctions.isInFrame(Dialogue, false);
    }

    // Update is called once per frame
    void Update()
    {
        // If user clicks space, dialogue box will show
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isDialogueShowing)
            {
                HelperFunctions.isInFrame(Dialogue, false);
                isDialogueShowing = false;
            }
            else
            {
                HelperFunctions.isInFrame(Dialogue, true);
                isDialogueShowing = true;
                HelperFunctions.changeDialogueText("hello");
            }
        }
    }
}
