using System.Collections;
using System.Collections.Generic;
using Floor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SetCheckPoint : MonoBehaviour
{
    [SerializeField] private RespawnPlayer respawnPlayer;
    [SerializeField] private Transform newSpawnPoint;

    private void OnCollisionEnter(Collision other)
    {
        if (newSpawnPoint == respawnPlayer.CheckPoint) return;
        
        respawnPlayer.CheckPoint = newSpawnPoint;
        Debug.Log("ChangedSpawn");

    }
}