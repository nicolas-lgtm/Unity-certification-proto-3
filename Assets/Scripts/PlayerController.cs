using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = false;
    public bool gameOver = false;

    private Animator playerAnim;
    private Rigidbody playerRb;

    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    [SerializeField] GameObject gameOverScreen;

     void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(!gameOver) dirtParticle.Play();
            isOnGround = true;
        } 
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            GameOver();
        }
    }

    private void Jump()
    {
        audioSource.PlayOneShot(jumpSound, 1f);
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger("Jump_trig");
        dirtParticle.Stop();
    }

    private void GameOver()
    {
        audioSource.PlayOneShot(crashSound, 1f);
        explosionParticle.Play();
        dirtParticle.Stop();
        gameOver = true;
        int randAnim = Random.Range(1, 3);
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", randAnim);
        gameOverScreen.SetActive(true);
    }
}
