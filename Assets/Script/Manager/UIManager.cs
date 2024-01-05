using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("�̼� UI")]
    public GameObject missionCanvas;
    [Header("���� UI")]
    public GameObject mainCanvas;
    [Header("ĳ���� ����")]
    public GameObject charSelectCanvas;
    public GameObject charCanvas;
    [Header("Ÿ�ϸ� UI")]
    public GameObject tileMapCanvas;
    [Header("ĳ���� ����â ��ư")]
    public Button[] charSelectButtons;
    [Header("ĳ���� ��ư")]
    public Button[] charButtons;

    protected override void Awake()
    {
        base.Awake();
        for(int i = 0; i < charButtons.Length; i++)
            charButtons[0].onClick.AddListener(()=> charCanvas.SetActive(true));
        for(int i = 0;i < charSelectButtons.Length;i++)
        {
            charSelectButtons[i].onClick.AddListener(() => CharInfoAdd(i));
        }
    }
    public void CharInfoAdd(int value)
    {
        GameManager.instance.playerCharacter[0] = value;
    }
    
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
        GameManager.instance.MissionNum = value;
        missionCanvas.SetActive(false);
        mainCanvas.SetActive(false);
        tileMapCanvas.SetActive(true);
    }
    public void CharacterSelect()
    {
        charSelectCanvas.SetActive(true);
        tileMapCanvas.SetActive(false);
    }
    public void CharacterSelectClose()
    {
        Debug.Log("������");
        charSelectCanvas.SetActive(false);
        tileMapCanvas.SetActive(true);
    }
    public void TileMapStart()
    {
        GameManager.instance.gameStartBool = true;
    }

}
