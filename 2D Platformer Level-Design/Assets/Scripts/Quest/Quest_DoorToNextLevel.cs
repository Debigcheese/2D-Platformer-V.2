using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_DoorToNextLevel : MonoBehaviour
{

    [SerializeField] int LevelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (collision.GetComponent<Quest_Player>().isQuestComplete == true)
            {
                GameObserver.SaveCoinsToMemory(collision.GetComponent<PlayerState>().coinAmount);
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }
}
