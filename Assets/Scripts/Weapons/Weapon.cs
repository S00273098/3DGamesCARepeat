using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public Camera playerCamera;

    private PlayerInputActions inputActions;

    private int currentAmmo;
    private float nextFireTime;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        currentAmmo = weaponData.magazineSize;
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        if (inputActions.Player.Shoot.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time < nextFireTime)
            return;

        if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }

        nextFireTime = Time.time + weaponData.fireRate;
        currentAmmo--;

        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, weaponData.range))
        {
            //EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();

            //if (enemy != null)
            //{
            //    enemy.TakeDamage(weaponData.damage);
            //}
        }

        Debug.Log("Shot! Ammo: " + currentAmmo);
    }
}