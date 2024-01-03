using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [Header("������")]
    public GameObject[] missionTiles;
    public GameObject[] Enemy;
    [Header("Ǯ ����Ʈ")]
    public List<GameObject> Tiles;
    public List<GameObject> unit01;
    public List<GameObject> unit02;


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        foreach( GameObject mission in missionTiles )
        {
            GameObject gameObj = Instantiate(mission);
            gameObj.transform.SetParent(transform);
            gameObj.SetActive(false);
            Tiles.Add(gameObj);
        }
        AddPool(Enemy[0], unit01, 5);
        AddPool(Enemy[1], unit02, 5);
    }

    public void AddPool(GameObject gameObject ,List<GameObject> list, int value)
    {
        for(int i = 0; i < value; i++) 
        {
            GameObject setGameObj = Instantiate(gameObject);
            setGameObj.transform.SetParent(transform);
            setGameObj.SetActive(false);
            list.Add(setGameObj);
        }
    }
    public void Pop(string unitName)
    {

    }
    
}
