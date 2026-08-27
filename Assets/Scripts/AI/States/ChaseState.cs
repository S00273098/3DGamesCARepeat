using UnityEngine;

public class ChaseState : IAIState
{
    private EnemyController enemy;

    public ChaseState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("AI entered CHASE state");

        enemy.agent.isStopped = false;
    }

    public void Update()
    {
        if (enemy.player == null)
            return;

        enemy.agent.SetDestination(enemy.player.position);

        float distance = enemy.DistanceToPlayer();

        if (distance <= enemy.attackRange)
        {
            enemy.ChangeState(enemy.AttackState);
        }
        else if (!enemy.CanSeePlayer())
        {
            enemy.ChangeState(enemy.PatrolState);
        }
    }

    public void Exit()
    {
    }
}