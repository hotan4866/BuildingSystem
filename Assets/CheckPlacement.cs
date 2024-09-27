using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    public BuildingManager buildingManager;

    private void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    // 충돌 시작
    private void OnTriggerEnter(Collider other)
    {
        // 충돌된 태그가 오브젝트라면
        if (other.gameObject.CompareTag("Object"))
        {
            // 배치 할수 없도록 변경
            buildingManager.canPlace = false;
        }
    }

    // 충돌 끝
    private void OnTriggerExit(Collider other)
    {
        // 충돌된 태그가 오브젝트라면
        if (other.gameObject.CompareTag("Object"))
        {
            // 배치 할 수 있도록
            buildingManager.canPlace = true;
        }
    }

}
