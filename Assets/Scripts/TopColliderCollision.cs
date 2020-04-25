using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopColliderCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") GameObject.Find("Game Manager").GetComponent<GameManager>().score++;
    }
}
