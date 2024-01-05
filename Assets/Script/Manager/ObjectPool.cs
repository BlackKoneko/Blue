using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("������")]
    public GameObject[] gameObjects;
    [Header("������ ����")]
    public int instanceNum; // ������ ����

    Dictionary<int, Stack<GameObject>> objectPoolDic; //������Ʈ Ǯ ����  

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        objectPoolDic = new Dictionary<int, Stack<GameObject>> ();

        for(int i  = 0; i < gameObjects.Length; i++)
        {
            objectPoolDic.Add(i , new Stack<GameObject>());
            AddPool(gameObjects[i], i);
        }
    }
    public void AddPool(GameObject gameObject , int objIndex = 0)
    {
        for(int i = 0; i < instanceNum; i++) 
        {
            GameObject setGameObj = Instantiate(gameObject);
            setGameObj.transform.SetParent(transform);
            setGameObj.SetActive(false);
            objectPoolDic[objIndex].Push(setGameObj);
        }
    }
    public void Pop(int objIndex)
    {
        if (objectPoolDic[objIndex].Count <= 0)  
        {
            AddPool(gameObjects[objIndex], objIndex);
        }
        GameObject enemyGameObj = objectPoolDic[objIndex].Pop();
        enemyGameObj.SetActive(true);
    }
    public void Return(GameObject gameObj, int objIndex = 0)
    {
        objectPoolDic[objIndex].Push(gameObj);
        gameObj.SetActive(false);
    }
   
}
