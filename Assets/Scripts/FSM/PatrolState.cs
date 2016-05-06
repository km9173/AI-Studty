using UnityEngine;
using System;

public class PatrolState : IState
{
    public void Run(MonsterCtrl monster)
    {
        if (monster.Detect())
        {
            //Debug.Log("Patrol Detect True");
            if (monster.GetTargetVisible())
            {
                //Debug.Log("Patrol GetTargetVisible True");
                if (monster.IsAttackable())
                {
                    //Debug.Log("Patrol IsAttackable True");
                    monster.ChangeState(
                        StateManager.GetIState(StateManager.State.Attack));
                }
                    
                else
                {
                    //Debug.Log("Patrol IsAttackable False");
                    monster.Move();
                    monster.ChangeState(
                        StateManager.GetIState(StateManager.State.Trace));
                }
            }

            else
            {
                // TODO: Set CheckPoint to Target Position
                monster.SetCheckpoint(Vector3.one);
                monster.Move();
                monster.ChangeState(
                    StateManager.GetIState(StateManager.State.Trace));
            }
        }

        else
        {
            // PaceAround function is moving distance in just during one frame
            monster.PaceAround();
            //monster.ChangeState(StateManager.GetIState(StateManager.State.Patrol));
        }
    }
}
