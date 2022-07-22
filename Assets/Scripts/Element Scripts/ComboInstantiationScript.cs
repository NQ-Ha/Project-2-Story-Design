using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboInstantiationScript : MonoBehaviour
{
    public GameObject instantiateObj;
    public float destroyTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateObject(Transform instantVec3)
    {
        var instantObj = Instantiate(instantiateObj, instantVec3.position, Quaternion.identity) as GameObject;
        Destroy(instantObj, destroyTime);
    }
}
