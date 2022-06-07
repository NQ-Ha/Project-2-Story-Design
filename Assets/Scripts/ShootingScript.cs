using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
    [RequireComponent(typeof(PlayerInput))]
#endif

    public class ShootingScript : MonoBehaviour
    {
        [Header("Object Data")]
        public GameObject lMouseProjectile;
        public GameObject rMouseProjectile;
        public Transform barrelExit;

        [Header("Highlights")]
        public GameObject lMouseHighlight;
        public GameObject rMouseHighlight;

        [Header("Projectile Variables")]
        public float projectileSpeed;
        public float fireRateLeft;
        public float fireRateRight;

        [Header("SerializeFields")]
        [SerializeField] bool lProjectileActive;
        [SerializeField] float currentFireRate;

        Camera cam;

        private Vector3 destination;
        private float timeToFireCurrent;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        private PlayerInput _playerInput;
#endif
        private CharacterController _controller;
        private StarterAssetsInputs _input;
        private GameObject _mainCamera;

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
            _controller = GetComponent<CharacterController>();
            _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif
            cam = _mainCamera.GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            if (lProjectileActive == true)
            {
                currentFireRate = fireRateLeft;
                lMouseHighlight.SetActive(true);
                rMouseHighlight.SetActive(false);
            }
            else if (lProjectileActive == false)
            {
                currentFireRate = fireRateRight;
                lMouseHighlight.SetActive(false);
                rMouseHighlight.SetActive(true);
            }

            if (Mouse.current.leftButton.isPressed && Time.time >= timeToFireCurrent)
            {
                timeToFireCurrent = Time.time + 1 / currentFireRate;
                ShootProjectile();
                if (lProjectileActive == true)
                    InstantiateProjectile(lMouseProjectile);
                else if (lProjectileActive == false)
                    InstantiateProjectile(rMouseProjectile);
            }
            else if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                if (lProjectileActive == true)
                    lProjectileActive = false;
                else if (lProjectileActive == false)
                    lProjectileActive = true;
            }
        }

        void ShootProjectile()
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                destination = hit.point;
                print(hit.point);
            }
            else
                destination = ray.GetPoint(1000);
        }

        void InstantiateProjectile(GameObject projectile)
        {
            var projectileObj = Instantiate(projectile, barrelExit.position, Quaternion.identity) as GameObject;
            projectileObj.GetComponent<Rigidbody>().velocity = (destination - barrelExit.position).normalized * projectileSpeed;
        }
    }
}
