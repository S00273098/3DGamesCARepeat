using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName = "Security Guard";

    [Header("Health")]
    public float maxHealth = 100f;

    [Header("Movement")]
    public float movementSpeed = 3.5f;

    [Header("Detection")]
    public float detectionRange = 10f;
    public float fieldOfView = 120f;

    [Header("Combat")]
    public float attackRange = 2f;
    public float attackDamage = 20f;
    public float attackCooldown = 1f;
}