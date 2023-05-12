using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float jumpPower;
    public GameObject gameController;
    public AudioClip jumpClip;
    public AudioClip gameOverClip;
    //public AudioClip gameMusicClip;

    private AudioSource audioSource;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButton(0) && gameController.GetComponent<GameController>().isStartgame)
        {
            if (!gameController.GetComponent<GameController>().isEndgame)
            {
                audioSource.clip = jumpClip;
                audioSource.Play();
            }            
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }
    void EndGame()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
