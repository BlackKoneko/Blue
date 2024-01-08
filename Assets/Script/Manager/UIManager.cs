using JetBrains.Annotations;
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
    public GameObject charSlotCanvas;
    [Header("Ÿ�ϸ� UI")]
    public GameObject tileMapCanvas;
    [Header("ĳ���� ����â ��ư")]
    public Button[] charSelectButtons;
    public Image[] charSelectSprite;
    public Button[] charSelectedButtons;
    [Header("ĳ���� ��ư")]
    public Button[] charButtons;
    [Header("ĳ���� �ʻ�ȭ")]
    public Sprite[] charSprite;
    public Dictionary<int, Sprite> charIMagesDic;

    protected override void Awake()
    {
        base.Awake();
        charIMagesDic = new Dictionary<int, Sprite>();
        for (int i = 0; i < charButtons.Length; i++)
            charButtons[i].onClick.AddListener(()=> charSlotCanvas.SetActive(true));
        for(int i = 0;i < charSelectButtons.Length;i++)
        {
            int num = i;
            charSelectButtons[i].onClick.AddListener(() => CharInfoAdd(num));
        }
        for(int i = 0;i < charSprite.Length; i++)
            charIMagesDic.Add(i, charSprite[i]);
        for (int i = 0; i < charSelectedButtons.Length; i++)
        {
            int num = i;
            charSelectedButtons[i].onClick.AddListener(() => CharInfoRemove(num));
        }
    }
    public void CharInfoAdd(int value)
    {
        for(int i = 0; i < charSelectSprite.Length; i++)
        {
            if (GameManager.instance.playerCharacter[i] != 0)
            {
                for(int j= 0; j< charSelectSprite.Length; j++)
                {
                    if (GameManager.instance.playerCharacter[i] == value)
                        return;
                }          
            }
            if (GameManager.instance.playerCharacter[i] == 0)
            {
                charSelectSprite[i].sprite = charIMagesDic[value];
                GameManager.instance.playerCharacter[i] = i+1;
                return;
            }
        }
    }
    public void CharInfoRemove(int value)
    {
        charSelectSprite[value].sprite = null;
        GameManager.instance.playerCharacter[value] = 0;
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
        charSelectCanvas.SetActive(false);
        tileMapCanvas.SetActive(true);
    }

    public void CharacterSelectSlotClose()
    {
        charSlotCanvas.SetActive(false);
        charSelectCanvas.SetActive(true);
    }
    public void TileMapStart()
    {
        GameManager.instance.gameStartBool = true;
    }

}
