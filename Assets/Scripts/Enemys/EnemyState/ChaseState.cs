using UnityEngine;

public class ChaseState : EnemyBaseState
{
    public ChaseState(Enemy enemy, string animationName) : base (enemy, animationName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        enemy.spriteRenderer.color = Color.blue;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!enemy.isChasing)
            enemy.SwitchState(enemy.patrolState);
        else if (enemy.CanAttack())
            enemy.SwitchState(enemy.attackState);
        enemy.ChasePlayer();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
