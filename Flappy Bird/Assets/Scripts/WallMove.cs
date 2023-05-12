using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float moveSpeed;
    public float minY;
    public float maxY;
    public float oldPos;

    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPos = 10;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("resetwall"))
        {
            obj.transform.position = new Vector3(oldPos, Random.Range(minY, maxY), 0);
        }
        
    }
}
