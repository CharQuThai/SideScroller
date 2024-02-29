using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Background background;
    [SerializeField] private SpawnManager spawnManager;


    public void EndGame()
    {
        Debug.Log("Game over");
        background.enabled = false;
        spawnManager.enabled = false;
        StartCoroutine(ResetAfterDelay(3));
        
    }

    IEnumerator ResetAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
        Reset();
    }

    public void Reset()
    {
        spawnManager.DestroyObstacles();
        background.enabled = true;
        spawnManager.enabled = true;
        playerController.Reset();
    }
}
