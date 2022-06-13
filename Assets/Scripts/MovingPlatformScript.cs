using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public GameObject moveObject;
    public Transform endPos;
    public float moveSpeed;
    public bool moveSwitch;

    [SerializeField] Vector3 originalPos;
    [SerializeField] Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = moveObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveSwitch == true)
        {
            destination = endPos.position;
        }
        else if(moveSwitch == false)
        {
            destination = originalPos;
        }

        moveObject.transform.position = Vector3.Lerp(moveObject.transform.position, destination, (Time.deltaTime *moveSpeed));
    }

    public void doorSwitch()
    {
        if (moveSwitch == true)
        {
            moveSwitch = false;
        }
        else if (moveSwitch == false)
        {
            moveSwitch = true;
        }
    }
}
