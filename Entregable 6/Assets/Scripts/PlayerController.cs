using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float jumpForce = 10;
    public float gravityModifier = 1f;
    public bool gameOver;
    private AudioSource playeraudioSource;
    private AudioSource cameraAudioSource;
    public AudioClip jumpClip;
    public AudioClip explosionClip;
    public ParticleSystem explosionParticleSystem;
    private float limY = 15f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playeraudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        cameraAudioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playeraudioSource.PlayOneShot(jumpClip, 1f);
        }

        if (transform.position.y <= -0.5f)
        {
            Destroy(gameObject);
            gameOver = true;
            Debug.Log(message: "GAME OVER");
            explosionParticleSystem.Play();
            cameraAudioSource.volume = 0.05f;
            playeraudioSource.PlayOneShot(explosionClip);
        }

        if (transform.position.y >= limY)
        {
            transform.position = new Vector3(transform.position.x, limY, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Bomb"))
            {

                gameOver = true;
                explosionParticleSystem.Play();                             
                cameraAudioSource.volume = 0.05f;
                playeraudioSource.PlayOneShot(explosionClip, 0.4f);

            }
        }
    }
}
