using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailingScript : MonoBehaviour
{
    public Vector3 destinationVec;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationVec, 1);
    }
}
