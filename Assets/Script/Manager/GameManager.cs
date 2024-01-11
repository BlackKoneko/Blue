using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
    public MissionStateMachine( IState state )
    {
        this.state = state;
    }
    public void SetState( IState state )
    {
        if (state == this.state)
            return;
        this.state.Exit();
        this.state = state;
        state.Enter();  
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
        MissionManager.instance.SetMission();
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
        
    }
}
public class EnemyTurnState : IState
{
    public void Enter()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}

public enum MissionState
{
    IDLE,
    START,
    MYTURN,
    ENEMYTURN
}

public class GameManager : Singleton<GameManager>
{

    [Header("미션 타일맵 선택")]
    private int missionnum;
    public int MissionNum
    {
        get { return missionnum; }
        set 
        { 
            missionnum = value;
            missionTile.Pop(MissionNum - 1);
            missionStateMachine = new MissionStateMachine(missionStateDic[MissionState.IDLE]);
        }
    }
    [Header("캐릭터 정보")]
    public int[] playerCharacter;
    public GameObject playerObj;
    [Header("게임 시작")]
    [SerializeField] private bool gameStartBool = false;
    public bool GameStartBool
    {
        get { return gameStartBool; }
        set 
        { 
            gameStartBool = value; 
            if(gameStartBool)
            {
                missionStateMachine.SetState(missionStateDic[MissionState.START]);
            }
            else
                missionStateMachine.SetState(missionStateDic[MissionState.IDLE]);
        }
    }
    [Header("미션 타일")]
    public ObjectPool missionTile;
    [Header("적 오브젝트 풀")]
    public ObjectPool enemyOP;
    [Header("플레이어 위치")]
    public Tile plPoint;
    /// <summary>
    /// 다음 턴으로 넘어갈때 실행할 함수
    /// </summary>
    public Action nextTurnAction;

    public MissionStateMachine missionStateMachine;

    public Dictionary<MissionState, IState> missionStateDic = new Dictionary<MissionState, IState>();

    private void Start()
    {
        IState idle = new IdleState();
        IState start = new StartState();
        IState myTurn = new MyTurnState();
        IState enemyTurn = new EnemyTurnState();

        missionStateDic.Add(MissionState.IDLE, idle);
        missionStateDic.Add(MissionState.START, start);
        missionStateDic.Add(MissionState.MYTURN, myTurn);
        missionStateDic.Add(MissionState.ENEMYTURN, enemyTurn);
    }

}
