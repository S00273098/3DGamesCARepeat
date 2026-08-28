using UnityEngine;

public class AttackState : IAIState
{
    private EnemyController enemy;

    private float attackCooldown;
    private float nextAttackTime;

    public AttackState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        attackCooldown = enemy.enemyData.attackCooldown;
        nextAttackTime = Time.time;

        Debug.Log("AI entered ATTACK state");

        enemy.agent.isStopped = true;
    }

    public void Update()
    {
        if (enemy.player == null)
            return;

        float distance = enemy.DistanceToPlayer();

        if (distance > enemy.enemyData.attackRange)
        {
            enemy.ChangeState(enemy.ChaseState);
            return;
        }

        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void Attack()
    {
        PlayerHealth playerHealth =
            enemy.player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(enemy.enemyData.attackDamage);
        }
    }

    public void Exit()
    {
        enemy.agent.isStopped = false;
    }
}