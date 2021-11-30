using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLateral : MonoBehaviour
{
    private float limR = 30f;
    public float speed = 10f;
    private PlayerController PlayerControllerScript;


    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!PlayerControllerScript.gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (transform.position.x > limR)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -limR)
        {
            Destroy(gameObject);
        }

    }
}
