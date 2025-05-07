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
        // ī�޶� �ϰ� �÷��̾� ������ �Ÿ��� �����ɰ� 
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
            // position ���� �����ö��� ������ �ѹ� �־��ٰ�
            // �ٽ� �����Ͽ� �������� ������ ���Ѿ� �Ѵ�.
        }
    }

    public void GameOver()
    {
        isDEAD = true;

    }
}
