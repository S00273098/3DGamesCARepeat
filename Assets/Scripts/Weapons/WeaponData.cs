using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName = "Pistol";

    public float damage = 25f;
    public float range = 50f;
    public float fireRate = 0.5f;

    public int magazineSize = 12;
}