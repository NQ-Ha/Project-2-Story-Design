using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaExplodeScript : MonoBehaviour
{
    public ParticleSystem plasmaExplodeFX;
    public GameObject smokePuffFX;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = plasmaExplodeFX.main.startSize.constant;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (plasmaExplodeFX.isPlaying == true)
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
        else
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == ("Breakable"))
        {
            var smokeFX = Instantiate(smokePuffFX, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(smokeFX, smokePuffFX.GetComponent<ParticleSystem>().main.startLifetime.constant);
        }
    }
}
