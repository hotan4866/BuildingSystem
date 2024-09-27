﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager: MonoBehaviour
{
    // 오브젝트 리스트
    public GameObject[] objects;

    // 히트된 오브젝트에 포지션
    private Vector3 pos;

    // 마우스 히트
    private RaycastHit hit;

    // 레이캐스트 레이어
    [SerializeField] private LayerMask layerMask;

    // 소환된 오브젝트
    private GameObject pendingObject;

    /*


    // 오브젝트 머티리얼 변경 위해 
    [SerializeField] private Material[] materials;



    public float rotateAmount;
    public float gridSize;

    bool gridOn = true;

    // 배치가 가능한 상태인지 확인
    public bool canPlace; 

    [SerializeField] private Toggle gridToggle;
    */

    private void FixedUpdate()
    {
        // 스크린 시야의 마우스에 광선을 쏨
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //마우스에서 히트된 오브젝트 
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            // 오브젝트에 포지션 대입
            pos = hit.point;
        }
    }
    public void SelectObject(int index)
    { 

        pendingObject = Instantiate(objects[index], pos, transform.rotation);
    }

    public void Update()
    {
        if (pendingObject != null)
        { 
            pendingObject.transform.position = pos;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }
        }
    }

    public void PlaceObject()
    {
        pendingObject = null;
    }

    /*
    private void Update()
    {
        if(pendingObject != null)
        {
            if(gridOn)
            {
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z));    
            }
            else 
            {
                pendingObject.transform.position = pos;
            }

            // 마우스 클릭 & 배치 가능 상태 인지 확인
            if(Input.GetMouseButtonDown(0) && canPlace)
            {
                // 오브젝트 배치하기 
                PlaceObject();
            }
            // r 키를 누르면
            if (Input.GetKeyDown(KeyCode.R))
            {
                // 오브젝트 회전하기
                RotateObject();
            }

            UpdateMaterials();
        }
    }



    private void RotateObject()
    {
        pendingObject.GetComponent<MeshRenderer>().material = materials[0];
        pendingObject = null;
    }

    private void PlaceObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    public void UpdateMaterials()
    {
        if (canPlace)
        { 
            pendingObject.GetComponent<MeshRenderer>().material = materials[0];
        }
        if (!canPlace)
        {
            pendingObject.GetComponent<MeshRenderer>().material = materials[1];
        }
    }



    private float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }

        return pos;
    }
    */
}
