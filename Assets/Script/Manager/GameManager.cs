using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("�̼� Ÿ�ϸ� ����")]
    public int missionNum;
    [Header("�̼� Ÿ�� ������Ʈ")]
    public GameObject[] missionTiles;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    public void MissionSelection()
    {

    }
}
