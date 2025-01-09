using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Follow Camera는 Player의 위치를 따라감
    // 이를 위해 target에 Player가 들어가야 함
    [SerializeField] Transform target;

    void Update()
    {
        // Follow Camera의 위치는 Player의 위치
        transform.position = target.position;
    }
}
