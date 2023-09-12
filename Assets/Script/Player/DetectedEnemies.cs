using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedEnemies : MonoBehaviour
{
    public List<Transform> enemies;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<EnemyBase>() != null)
        {
            enemies.Add(collider.transform);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<EnemyBase>() != null)
        {
            enemies = enemies.FindAll(p => p != collider.transform);
        }
    }

#pragma warning disable IDE1006
    public Transform getEnemyClosed(Transform player)
    {
        Vector3 playerPos = player.position;
        if (enemies.Count > 0)
        {
            Transform enemyTarget = enemies[0];
            float distance = 1000000f;

            for (int i = 0; i < enemies.Count; i++)
            {
                if (Vector3.Distance(enemies[i].position, playerPos) < distance)
                {
                    distance = Vector3.Distance(playerPos, enemies[i].position);
                    enemyTarget = enemies[i];
                }
            }

            return enemyTarget;
        }
        else return player;
    }
}
