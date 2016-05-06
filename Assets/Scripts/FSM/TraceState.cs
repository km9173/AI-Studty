using UnityEngine;
using System.Collections;
using System;

public class TraceState : IState
{
    public void Run(MonsterCtrl monster)
    {
        if (monster.Detect())
        {
            if (monster.IsAttackable())
            {
                monster.ChangeState(
                    StateManager.GetIState(StateManager.State.Attack));
            }
            else
            {
                //monster.SetCheckpoint();
                monster.Move();
                monster.ChangeState(
                    StateManager.GetIState(StateManager.State.Trace));
            }
        }
        else
        {
            if (monster.GetDistance(monster.GetCheckpoint()) == 0)
            {
                monster.ChangeState(
                    StateManager.GetIState(StateManager.State.Patrol));
            }
            else
            {
                monster.Move();
                monster.ChangeState(
                    StateManager.GetIState(StateManager.State.Trace));
            }            
        }
    }
}
