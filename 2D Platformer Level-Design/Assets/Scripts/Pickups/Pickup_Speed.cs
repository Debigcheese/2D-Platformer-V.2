using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Speed : MonoBehaviour
{
    [SerializeField] private float multiplyspeedBy = 1.5f;

    private PlayerMovement playerMovement;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioclip;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem particles;

    private bool isUsingMovementSpeed;

    private float timer = 0f;
    [SerializeField] private float timeBeforeReset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
        if (isUsingMovementSpeed == true)
        {
            timer += Time.deltaTime;
            if(timer >= timeBeforeReset)
            {
                playerMovement.ResetMovementSpeed();
                timer = 0f;
                isUsingMovementSpeed = false;
                spriteRenderer.enabled = true;
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsingMovementSpeed == false)
        {
        if (collision.CompareTag("Player") == true)
        {
            if(playerMovement == null)
            {
                playerMovement = collision.GetComponent<PlayerMovement>();
            }
                isUsingMovementSpeed = true;
                playerMovement.SetNewMovementSpeed(multiplyspeedBy);
                audioSource.PlayOneShot(audioclip);
                spriteRenderer.enabled = false;
                particles.Play();

            }
        }
    }

}


