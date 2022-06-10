using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject impactVFX;

    private bool collided;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Bullet" && other.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(impactVFX, other.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 1);
            Destroy(gameObject);
        }
    }
}
