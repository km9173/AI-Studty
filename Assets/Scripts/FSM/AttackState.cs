using UnityEngine;
using System.Collections;
using System;

public class AttackState : IState
{
    public void Run(MonsterCtrl monster)
    {
        monster.Attack();

        if (monster.Detect())
        {
            if (monster.IsAttackable())
            {
                //return this;
            }
            else
            {
                monster.ChangeState(
                    StateManager.GetIState(StateManager.State.Trace));
            }
        }

        else
        {
            monster.Move();
            monster.ChangeState(
                StateManager.GetIState(StateManager.State.Patrol));
        }
    }
}
