using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("�̼� UI")]
    public GameObject missionCanvas;
    [Header("���� UI")]
    public GameObject mainCanvas;

    //���� ȭ�� ����
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
    
    //�̼� ȭ�� ����
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
