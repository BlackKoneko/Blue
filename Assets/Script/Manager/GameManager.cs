using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("미션 타일맵 선택")]
    public int missionNum;
    [Header("미션 타일 오브젝트")]
    public GameObject[] missionTiles;

    private void Update()
    {
        
    }

    public void MissionSelection()
    {

    }
}
