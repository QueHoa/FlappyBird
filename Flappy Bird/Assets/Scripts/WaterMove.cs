using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;

    private Vector2 oldPos;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPos = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(- moveSpeed * Time.deltaTime, 0, 0)); 
        if (Vector3.Distance(oldPos, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPos;
        }
    }
}
