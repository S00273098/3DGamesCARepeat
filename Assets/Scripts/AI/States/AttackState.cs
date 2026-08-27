using UnityEngine;

public class AttackState : IAIState
{
    private EnemyController enemy;

    private float attackCooldown = 1f;
    private float nextAttackTime;

    public AttackState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("AI entered ATTACK state");

        enemy.agent.isStopped = true;
    }

    public void Update()
    {
        if (enemy.player == null)
            return;

        float distance = enemy.DistanceToPlayer();

        if (distance > enemy.attackRange)
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
        Debug.Log("Enemy attacks player!");
    }

    public void Exit()
    {
        enemy.agent.isStopped = false;
    }
}