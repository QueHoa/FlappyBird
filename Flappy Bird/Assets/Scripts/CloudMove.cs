using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speedMove = 0.5f;
    private GameObject obj;
    private Vector2 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPos = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(Time.deltaTime * speedMove, 0, 0));
        if (Vector3.Distance(oldPos, obj.transform.position) >= 0.5f)
        {
            speedMove = -speedMove;
        }
    }
}
