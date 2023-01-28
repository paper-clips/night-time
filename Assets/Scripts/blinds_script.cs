using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinds_script : MonoBehaviour
{
    public Camera cam;
    public Animator blindsAnimator;
    public AudioSource blindsOpenSound;     // Audio Source: https://pixabay.com/sound-effects/window-blinds-open-close-2-37743/
    public AudioSource blindsCloseSound;
    bool wereBlindsClicked;
    bool areBlindsClosed;

    // Start is called before the first frame update
    void Start()
    {
        wereBlindsClicked = false;
        areBlindsClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If user clicks on blinds, open/close them accordingly
        if (HelperFunctions.didUserClickObject("blinds", cam))
        {
            wereBlindsClicked = true;
            blindsAnimator.SetBool("wereBlindsClicked", true);

            if (areBlindsClosed)    // Open blinds
            {
                blindsOpenSound.Play();
                blindsAnimator.SetBool("areBlindsClosed", false);
                areBlindsClosed = false;
            }
            else      // Close blinds
            {
                blindsCloseSound.Play();
                blindsAnimator.SetBool("areBlindsClosed", true);
                areBlindsClosed = true;
            }
        }
        // Reset trigger
        else if (wereBlindsClicked == true && (blindsAnimator.GetCurrentAnimatorStateInfo(0).IsName("openBlinds") || blindsAnimator.GetCurrentAnimatorStateInfo(0).IsName("closeBlinds")))
        {
            blindsAnimator.SetBool("wereBlindsClicked", false);
            wereBlindsClicked = false;
        }
    }
}
