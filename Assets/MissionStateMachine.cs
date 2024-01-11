using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Enter();
    public void Update();
    public void Exit();
}
public class MissionStateMachine
{
    public IState state;
    public MissionStateMachine(IState state)
    {
        this.state = state;
    }
    public void SetState(IState state)
    {
        if (state == this.state)
            return;
        this.state.Exit();
        this.state = state;
        this.state.Enter();
    }

    public void StateUpdate()
    {
        state.Update();
    }

}
public class IdleState : IState
{
    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void Update()
    {

    }
}
public class StartState : IState
{
    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            GameManager.instance.StartStateUpdate();
    }
}
public class MyTurnState : IState
{
    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            GameManager.instance.MyTurnStateUpdate();
    }
}
public class EnemyTurnState : IState
{
    public void Enter()
    {
        GameManager.instance.SetMissionState(MissionState.MYTURN);
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}
