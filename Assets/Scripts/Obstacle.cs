using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float highPosY = 0.5f;
    public float lowPosY = -0.5f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;


    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastposition, int obstaclCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placeposition = lastposition + new Vector3(widthPadding, 0);
        placeposition.y = -2f + Random.Range(lowPosY, highPosY); // 원래 코드에서 - 2정도 내렸음


        transform.position = placeposition;
        return placeposition;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            gameManager.AddScore(1);
        }
    }
}
