using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    public Player player;
    public Transform hitPoint;
    public float rangeHit;
    // Start is called before the first frame update
    public void Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(hitPoint.position, rangeHit);
        List<EnemyBase> enemies = new List<EnemyBase>();
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<EnemyBase>() != null) enemies.Add(c.GetComponent<EnemyBase>());
        }
        player.damages.Invoke(enemies);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hitPoint.position, rangeHit);
    }
}
