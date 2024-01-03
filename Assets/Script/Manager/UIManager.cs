using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("미션 UI")]
    public GameObject missionCanvas;
    [Header("메인 UI")]
    public GameObject mainCanvas;

    //메인 화면 관련
    public void MainStart()
    {
        missionCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void MainSetting()
    {
        
    }

    public void MainExit()
    {
        Application.Quit();
    }
    
    //미션 화면 관련
    public void MissionExit()
    {
        missionCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
    public void Missions(int value)
    {
        GameManager.instance.missionNum = value;
        missionCanvas.SetActive(false);
        mainCanvas.SetActive(false);
    }

}
