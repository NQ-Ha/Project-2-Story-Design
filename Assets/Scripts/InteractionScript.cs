using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    public float interactRange;
    public GameObject interactText;

    [SerializeField] Camera cam;
    [SerializeField] private GameObject _mainCamera;
    private Vector3 destination;
    private ActivationObjectScript activationScript;

    public SimpleInput _input;


    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);

        _input = GetComponent<SimpleInput>();

        cam = _mainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector2 (0.5f,0.5f));
        RaycastHit hit;
        destination = ray.GetPoint(interactRange);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "modeSwitch" || hit.collider.gameObject.tag == "modeButton")
            {
                interactText.SetActive(true);
                activationScript = hit.collider.gameObject.GetComponent<ActivationObjectScript>();
                if(_input.Player.Interact.triggered)
                {
                    print("Activate Object");
                    activationScript.activateTrigger();
                }
            }
            else
            {
                interactText.SetActive(false);
            }
        }
    }
}
