using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public TMP_Text healthText;

    public Weapon weapon;
    public TMP_Text ammoText;

    private void Update()
    {
        UpdateHealth();
        UpdateAmmo();
    }

    private void UpdateHealth()
    {
        if (playerHealth == null)
            return;

        healthText.text =
            "Health: " + Mathf.CeilToInt(playerHealth.CurrentHealth);
    }
    private void UpdateAmmo()
    {
        if (weapon == null)
            return;

        ammoText.text =
            "Ammo: " + weapon.CurrentAmmo;
    }
}