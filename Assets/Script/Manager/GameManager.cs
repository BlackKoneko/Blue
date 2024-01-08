using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        }
    }
    [Header("캐릭터 정보")]
    public int[] playerCharacter;
    [Header("게임 시작")]
    public bool gameStartBool = false;
    [Header("미션 타일")]
    public ObjectPool missionTile;
    [Header("적 오브젝트 풀")]
    public ObjectPool enemyOP;

 
}
