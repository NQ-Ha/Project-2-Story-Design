using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricChainScript : MonoBehaviour
{
    public GameObject staticRangeObj;
    public GameObject staticOriginObj;
    public float staticRangeScale;

    public GameObject projectileObj;
    public GameObject trailFX;
    public bool staticTouch;

    [SerializeField] List<GameObject> primedObjList = new List<GameObject>();

    private Vector3 staticRangeVector3;
    private PrimeElementScript originElementScript;

    // Start is called before the first frame update
    void Start()
    {
        staticRangeVector3 = new Vector3(staticRangeScale, staticRangeScale, staticRangeScale);
        originElementScript = staticOriginObj.GetComponent<PrimeElementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(originElementScript.cdCountDown == originElementScript.cdTime && originElementScript.otherElement.triggerElectric == true)
        {
            staticTouch = true;
        }
        else if(originElementScript.cdCountDown <= 0 )
        {
            staticTouch = false;
        }

        if (staticTouch == true)
        {
            staticRangeObj.transform.localScale = staticRangeVector3*(originElementScript.cdTime*(originElementScript.cdTime - originElementScript.cdCountDown));
        }
        else if(staticTouch == false)
        {
            staticRangeObj.transform.localScale = new Vector3(0,0,0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Primed" && other.gameObject != staticOriginObj)
        {
            if(other.gameObject.GetComponent<PrimeElementScript>() == true)
            {
                PrimeElementScript otherPrimeScript = other.gameObject.GetComponent<PrimeElementScript>();
                if (otherPrimeScript.cdCheck == false)
                {
                    InstantiateTrail(trailFX, other.gameObject.transform.position);
                    InstantiateProjectile(projectileObj, other.gameObject.transform.position);
                    if (!primedObjList.Contains(other.gameObject))
                    {
                        primedObjList.Add(other.gameObject);
                    }
                }
                else if(otherPrimeScript.cdCheck == true)
                {
                    
                }
            }
        }
        else if (other.gameObject.tag == "modeTrigger")
        {
            InstantiateTrail(trailFX, other.gameObject.transform.position);
            ActivationObjectScript activateScript = other.gameObject.GetComponent<ActivationObjectScript>();
            activateScript.activateTrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Primed" && other.gameObject != staticOriginObj && primedObjList.Contains(other.gameObject))
        {
            primedObjList.Remove(other.gameObject);
        }
    }

    void InstantiateProjectile(GameObject projectile, Vector3 destination)
    {
        var projectileObj = Instantiate(projectile, destination, Quaternion.identity) as GameObject;
    }

    void InstantiateTrail(GameObject projectile, Vector3 destination)
    {
        var trailObj = Instantiate(projectile, staticOriginObj.transform.position, Quaternion.identity) as GameObject;
        trailObj.GetComponent<TrailingScript>().destinationVec = destination;
        Destroy(trailObj, 0.5f);
    }
}
