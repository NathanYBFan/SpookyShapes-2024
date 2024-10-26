using NaughtyAttributes;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    // Getters & Setters
    public int CurrentHP { get => currentHP; }
    public int MaxHP { set => maxHP = value; }

    // Private Variables
    [SerializeField, ReadOnly] private int currentHP = 5;
    [SerializeField, ReadOnly] private int maxHP = 5;

    public void TakeDamage(int damageToTake)
    {
        currentHP -= damageToTake;
        CheckIfDead();
    }

    public void HealHP(int amountToHeal)
    {
        currentHP = Mathf.Clamp(currentHP + amountToHeal, 0, maxHP);
    }

    private void CheckIfDead()
    {
        if (currentHP > 0) return;

        GameManager.Instance.GameOver();
    }

}
