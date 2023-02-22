using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    private Animator animator;
    public int healthPoints = 3;
    public int initialHealthPoints = 3;
    
    public int coinAmount = 0;
    public Text deathCounterText;

    private GameObject RespawnPosition;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip HurtClip;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private bool useStartPosition = true;

    // Start is called before the first frame update
    void Start()

    {
        animator = gameObject.GetComponent<Animator>();

        healthPoints = initialHealthPoints;
        if (useStartPosition == true)
        {
            gameObject.transform.position = startPosition.transform.position;
        }
        
        RespawnPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoHarm(int doHarmByThisMuch)
    {
        healthPoints -= doHarmByThisMuch;
        if (healthPoints <= 0) {
            Respawn();
           
        }
        animator.SetTrigger("doHarm");
        audioSource.PlayOneShot(HurtClip);
    }

    public void Respawn()
    {
        DeathCounter.IncrementDeaths();
        healthPoints = initialHealthPoints;
        gameObject.transform.position = RespawnPosition.transform.position;
    }

    public void CoinPickup()
    {
        coinAmount++;
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition)
    {
        RespawnPosition = newRespawnPosition;
    }
}
