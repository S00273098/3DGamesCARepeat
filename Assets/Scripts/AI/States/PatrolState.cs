using UnityEngine;

public class PatrolState : IAIState
{
    private EnemyController enemy;

    public PatrolState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("AI entered PATROL state");

        enemy.agent.isStopped = false;
    }

    public void Update()
    {
        if (enemy.CanSeePlayer())
        {
            enemy.ChangeState(enemy.ChaseState);
        }
    }

    public void Exit()
    {
    }
}