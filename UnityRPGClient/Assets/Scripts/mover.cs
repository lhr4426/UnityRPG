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
        if (Input.GetMouseButton(0)) // 0번 버튼 = 왼쪽 마우스 버튼
        {
           MoveToCursor(); 
        }
        // Debug.DrawRay(lastRay.origin, lastRay.direction * 100); // 레이 그리기



        UpdateAnimator();
        

    }

    // 마우스 왼쪽 클릭 했을 때, 클릭한 위치를 NavMeshAgent의 도착지로 설정
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit); // out 키워드를 사용함으로써 RaycastHit 형태의 결과가 hit에 포함됨. Raycast 함수 자체는 bool을 return.
        if (hasHit)
        {
            MoveTo(hit.point);
        }
    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
    }

    private void UpdateAnimator()
    {
        // 1. 내비메시 속도 구하기
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        
        // 2. 캐릭터 속도로 바꾸기
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); // InverseTransformDirection = global -> local

        // 3. 애니메이터 로컬변수 값 Z축 속도로 바꾸기
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        
        

    }




}

