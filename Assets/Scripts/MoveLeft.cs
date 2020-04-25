using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerController playerControllerScript;
    private GameManager gameManager;
    private float leftBound = -15f;
    private float timeElapsed = 0;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * (gameManager.timeElapsed / 40 + 1));
        }

        if((transform.position.x < leftBound) && (gameObject.CompareTag("Obstacle")))
        {
            Destroy(gameObject);
        }
    }
}
