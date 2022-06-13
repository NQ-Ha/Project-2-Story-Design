using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject impactVFX;

    TriggerElementScript triggerElementScript;

    private bool collided;
    private ActivationObjectScript activationScript;

    private void Start()
    {
        triggerElementScript = gameObject.GetComponent<TriggerElementScript>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Bullet" && other.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(impactVFX, other.contacts[0].point, Quaternion.identity) as GameObject;
            if (other.gameObject.tag == "modeTrigger" && triggerElementScript.triggerElectric == true)
            {
                activationScript = other.gameObject.GetComponent<ActivationObjectScript>();
                activationScript.activateTrigger();
            }
            Destroy(impact, 1);
            Destroy(gameObject);
        }
    }
}
