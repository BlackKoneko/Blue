using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;



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
            SetMissionState(MissionState.START);
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
                SetMissionState(MissionState.MYTURN);
            }
            else
                SetMissionState(MissionState.START);
        }
    }
    [Header("미션 타일")]
    public ObjectPool missionTile;
    [Header("적 오브젝트 풀")]
    public ObjectPool enemyOP;
    [Header("플레이어 위치")]
    public Tile plPoint;
    public MissionStateMachine missionStateMachine;

    public Dictionary<MissionState, IState> missionStateDic = new Dictionary<MissionState, IState>();

    public Action StartStateUpdate;
    public Action MyTurnStateUpdate;

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

        missionStateMachine = new MissionStateMachine(idle);
    }

    public void SetMissionState(MissionState missionState)
    {
        switch(missionState)
        {
            case MissionState.IDLE:
                missionStateMachine.SetState(missionStateDic[MissionState.IDLE]);
                break;
            case MissionState.START:
                missionStateMachine.SetState(missionStateDic[MissionState.START]);
                break;
            case MissionState.MYTURN:
                missionStateMachine.SetState(missionStateDic[MissionState.MYTURN]);
                break;
            case MissionState.ENEMYTURN:
                missionStateMachine.SetState(missionStateDic[MissionState.ENEMYTURN]);
                break;
        }
    }
    private void Update()
    {
        missionStateMachine.StateUpdate();
    }
}
