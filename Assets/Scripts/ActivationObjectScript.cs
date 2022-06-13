using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationObjectScript : MonoBehaviour
{
    [Header("Interaction Type")]
    public bool typePlayer;
    public bool typeElement;

    [Header("Associated Scripts")]
    public MovingPlatformScript movingPlatformScript;


    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.tag == "modeWeight")
        {
            if (other.gameObject.tag == "Player")
            {
                print("This is Active");
                movingPlatformScript.moveSwitch = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (gameObject.tag == "modeWeight")
        {
            if (other.collider.tag == "Player")
            {
                movingPlatformScript.moveSwitch = false;
            }
        }
    }

    public void activateTrigger()
    {
        movingPlatformScript.doorSwitch();
    }
}
