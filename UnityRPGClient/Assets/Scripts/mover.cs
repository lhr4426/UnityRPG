using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {        
        // 마우스 왼쪽 클릭한 위치로 캐릭터를 이동시키기
        if (Input.GetMouseButtonDown(0)) // 0번 버튼 = 왼쪽 마우스 버튼
        {
           MoveToCursor(); 
        }
        // Debug.DrawRay(lastRay.origin, lastRay.direction * 100); // 레이 그리기
    }

    // 마우스 왼쪽 클릭 했을 때, 클릭한 위치를 NavMeshAgent의 도착지로 설정
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit); // out 키워드를 사용함으로써 RaycastHit 형태의 결과가 hit에 포함됨. Raycast 함수 자체는 bool을 return.
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
}

