using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int baseDamage = 3;

    public void LaunchAttack()
    {
        // Check if it hits
        
        // Find player 
        GameManager.Instance.MainPlayer.GetComponent<PlayerController>().TakeDamage(CalculateDamage());
    }

    // Add scaling later
    public int CalculateDamage()
    {
        return baseDamage;
    }
}
