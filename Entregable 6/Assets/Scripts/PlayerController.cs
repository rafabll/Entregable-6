using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float jumpForce = 10;
    public float gravityModifier = 1;
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
        }

        if (transform.position.y >= limY)
        {
            transform.position = new Vector3(transform.position.x, limY, transform.position.z);
        }
    }
}
