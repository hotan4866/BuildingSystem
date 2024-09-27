using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private BuildingManager buildingManager;
    public GameObject selectedObj;
    public GameObject selectUI;

    public TextMeshProUGUI objNameText;

    private void Start()
    {
        buildingManager = GameObject.Find("BuildingManager")
            .GetComponent<BuildingManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Object"))
                {
                    Select(hit.collider.gameObject);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Deselect();
        }
    }

    private void Select(GameObject obj)
    {
        if (obj == selectedObj) return;
        if (selectedObj != null) Deselect();

        Outline outline = obj.GetComponent<Outline>();
        
        if (outline == null)
        {
            obj.AddComponent<Outline>();
        }
        else { outline.enabled = true; }

        objNameText.text = obj.name;
        selectedObj = obj;
        selectUI.SetActive(true);
    }

    private void Deselect()
    { 
        selectedObj.GetComponent<Outline>().enabled = false;
        selectUI.SetActive(false);
        selectedObj = null;
    }

    public void Delete()
    {
        GameObject objToDestroy = selectedObj;
        Deselect();
        Destroy(objToDestroy);
    }

    public void Move()
    {
        buildingManager.pendingObject = selectedObj;
    }
}
