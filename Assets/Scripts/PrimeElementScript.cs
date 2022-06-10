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
    [SerializeField] TriggerElementScript otherElement;
    [SerializeField] bool cdCheck;
    [SerializeField] float cdCountDown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cdCheck == true)
        {
            cdCountDown -= Time.deltaTime;
            if(cdCountDown <= 0)
            {
                cdCheck = false;
                cdCountDown = 0;
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

    // Effect of a primed fire and a trigger electric combo
    public void fireElectricCombo()
    {

    }

    // Effect of a primed fire and a trigger nature combo
    public void fireNatureCombo()
    {

    }

    // Effect of a primed water and a trigger electric
    public void waterElectricCombo()
    {

    }

    // Effect of a primed water and a trigger nature
    public void waterNatureCombo()
    {

    }

    // Effect of a double electric combo
    public void electricElectircCombo()
    {

    }

    // Effect of a primed electric and trigger nature combo 
    public void electricNatureCombo()
    {

    }

    // Effect of a primed nature and a trigger electric combo
    public void natureElectricCombo()
    {

    }

}
