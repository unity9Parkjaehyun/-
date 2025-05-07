using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    bool isDEAD = false;


    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
        // 카메라 하고 플레이어 사이의 거리가 유지될것 
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        if (isDEAD == false)
        {
            Vector3 pos = transform.position;
            pos.x = target.position.x + offsetX;
            transform.position = pos;
            // position 값을 가져올때는 변수에 한번 넣었다가
            // 다시 변조하여 가져오는 순서를 지켜야 한다.
        }
    }

    public void GameOver()
    {
        isDEAD = true;

    }
}
