using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTile : MonoBehaviour
{
    public GameObject[] moveTile;
    public LayerMask TileLayer;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            OnMouseDown();
    }

    public void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, TileLayer))
        {
            if(hit.transform.gameObject.name == "StartTile" && GameManager.instance.gameStartBool == false)
            {
                Debug.Log("들어왔다");
                UIManager.instance.CharacterSelect();
            }
        }
    }
}
