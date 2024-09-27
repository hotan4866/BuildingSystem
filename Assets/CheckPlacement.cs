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

    // �浹 ����
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� �±װ� ������Ʈ���
        if (other.gameObject.CompareTag("Object"))
        {
            // ��ġ �Ҽ� ������ ����
            buildingManager.canPlace = false;
        }
    }

    // �浹 ��
    private void OnTriggerExit(Collider other)
    {
        // �浹�� �±װ� ������Ʈ���
        if (other.gameObject.CompareTag("Object"))
        {
            // ��ġ �� �� �ֵ���
            buildingManager.canPlace = true;
        }
    }

}
