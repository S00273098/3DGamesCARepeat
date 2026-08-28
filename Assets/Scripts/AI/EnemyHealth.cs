using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyData enemyData;

    private float currentHealth;

    public float CurrentHealth => currentHealth;

    private void Start()
    {
        currentHealth = enemyData.maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log("Enemy health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");

        EnemyController controller =
            GetComponent<EnemyController>();

        if (controller != null)
        {
            controller.ChangeState(controller.DeadState);
        }

        Destroy(gameObject, 2f);
    }
}