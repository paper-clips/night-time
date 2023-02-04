using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_script : MonoBehaviour
{
    public GameObject Dialogue;
    public UnityEngine.UI.Text Text;

    // Start is called before the first frame update
    void Start()
    {
        HelperFunctions.isInFrame(Dialogue, false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
