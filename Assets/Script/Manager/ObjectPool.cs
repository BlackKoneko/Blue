using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("ÇÁ¸®ÆÕ")]
    public GameObject[] gameObjects;
    Dictionary<int, Stack<GameObject>> objectPoolDic;   

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
            for(int j = 0; j < 5; j++)
                AddPool(gameObjects[i], i);
        }
    }

    public void AddPool(GameObject gameObject , int objIndex = 0)
    {
        for(int i = 0; i < 5; i++) 
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
