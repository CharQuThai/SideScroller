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
    }
}
