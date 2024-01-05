using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("�̼� Ÿ�ϸ� ����")]
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
    [Header("ĳ���� ����")]
    public int[] playerCharacter;
    [Header("���� ����")]
    public bool gameStartBool = false;
    [Header("�̼� Ÿ��")]
    public ObjectPool missionTile;
    [Header("�� ������Ʈ Ǯ")]
    public ObjectPool enemyOP;

 
}
