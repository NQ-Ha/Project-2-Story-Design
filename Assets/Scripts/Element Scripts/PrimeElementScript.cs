using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeElementScript : MonoBehaviour
{
    [Header("Primed Magic Type")]
    public bool primeFire;
    public bool primeWater;
    public bool primeElectric;
    public bool primeNature;

    [Header("Primed Magic Variables")]
    public float cdTime = 3;

    [Header("")]
    public TriggerElementScript otherElement;
    public bool cdCheck;
    public float cdCountDown;
    public Material inertMaterial;
    public Material originalMaterial;

    private GameObject comboElementSystem;
    private ComboElementScript comboElementScript;

    private void Awake()
    {
        comboElementSystem = GameObject.FindGameObjectWithTag("comboElementScript");
        inertMaterial = GameObject.FindGameObjectWithTag("inertMaterial").GetComponent<MeshRenderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        comboElementScript = comboElementSystem.GetComponent<ComboElementScript>();
        originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdCheck == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = inertMaterial;
            cdCountDown -= Time.deltaTime;
            if (cdCountDown > 0)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = (originalMaterial.color*(cdTime*(cdTime-cdCountDown)));
            }
            else if (cdCountDown <= 0)
            {
                cdCheck = false;
                cdCountDown = 0;
                gameObject.GetComponent<MeshRenderer>().material = originalMaterial;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<TriggerElementScript>() == true)
        {
            otherElement = other.gameObject.GetComponent<TriggerElementScript>();
            print(other.gameObject + " trigger Electric: " + otherElement.triggerElectric + " | " + "trigger Nature: " + otherElement.triggerNature);
        }
        else
        {
            print(other.gameObject + ": No script is here");
        }

        if (cdCheck == false)
        {
            if (primeFire == true)
            {
                if (otherElement.triggerElectric == true)
                {

                }
                else if (otherElement.triggerNature == true)
                {

                }
            }
            else if (primeWater == true)
            {
                if (otherElement.triggerElectric == true)
                {

                }
                else if (otherElement.triggerNature == true)
                {

                }
            }
            else if (primeElectric == true)
            {
                if (otherElement.triggerElectric == true)
                {

                }
                else if (otherElement.triggerNature == true)
                {

                }
            }
            else if (primeNature == true)
            {
                if (otherElement.triggerElectric == true)
                {

                }
                else if (otherElement.triggerNature == true)
                {

                }
            }
            else
            {
                print("No Primed Element found.");
            }
            cdCheck = true;
            cdCountDown = cdTime;
        }
    }
}
