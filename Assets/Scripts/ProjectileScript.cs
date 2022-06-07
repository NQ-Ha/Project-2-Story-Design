using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private bool collided;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Bullet" && other.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    }
}
