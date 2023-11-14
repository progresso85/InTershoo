using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {   
        // do a listener on the key W, on press "input System V2"
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            Debug.Log("W was pressed");
        }
    }
}
