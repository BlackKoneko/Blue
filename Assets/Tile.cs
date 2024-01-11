using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    public enum TileType
    {
        NONE,
        START,
    }
    public TileType tileType;
    public int value;
    public bool moveable;
    public TileNode tileNode;

    private void Awake()
    {
        tileNode = new TileNode(value);

        GameManager.instance.nextTurnAction += () => { moveable = false; };
        //����ƽ �̸� ������Ÿ�ӿ� ���� �ǹǷ� ���� ����
        //�ٸ� ����ƽ �ƴѰ��� ���� �Ǵ� ������ ��ȣ�� ���Ƿ� ���� �߻� ���ɼ� ����(����õ)
    }
}
