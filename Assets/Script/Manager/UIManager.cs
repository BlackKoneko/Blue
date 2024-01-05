using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("미션 UI")]
    public GameObject missionCanvas;
    [Header("메인 UI")]
    public GameObject mainCanvas;
    [Header("캐릭터 선택")]
    public GameObject charSelectCanvas;
    public GameObject charCanvas;
    [Header("타일맵 UI")]
    public GameObject tileMapCanvas;
    [Header("캐릭터 선택창 버튼")]
    public Button[] charButtons;

    private void Awake()
    {
        //for(int i = 0; i < charButtons.Length; i++)
        //    charButtons[0].onClick.AddListener(()=> charCanvas.SetActive(true));
    }
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
        GameManager.instance.MissionNum = value;
        missionCanvas.SetActive(false);
        mainCanvas.SetActive(false);
        tileMapCanvas.SetActive(true);
    }
    public void CharacterSelect()
    {
        Debug.Log(charSelectCanvas.name);
        Debug.Log(tileMapCanvas.name);
        charSelectCanvas.SetActive(true);
        tileMapCanvas.SetActive(false);
    }
    public void CharacterSelectClose()
    {
        Debug.Log("나들어옴");
        charSelectCanvas.SetActive(false);
        tileMapCanvas.SetActive(true);
    }
    public void TileMapStart()
    {
        GameManager.instance.gameStartBool = true;
    }

}
