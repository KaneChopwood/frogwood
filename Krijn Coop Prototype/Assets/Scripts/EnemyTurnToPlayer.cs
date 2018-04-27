using UnityEngine;
using System.Collections;

public class EnemyTurnToPlayer : MonoBehaviour
{
    public Transform target;


    private void TurnToPlayer()
    {
        target = GameObject.Find("Player").transform;
        transform.LookAt(target);
    }


    
}