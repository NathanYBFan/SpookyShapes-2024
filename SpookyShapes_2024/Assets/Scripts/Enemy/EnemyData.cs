using UnityEngine;


[CreateAssetMenu(fileName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public Texture[] AttackAnimations;
    public Texture IdleFrame;
    public Texture DeadFrame;
    public Material monsterMat;

    public int maxHP;
    public int baseDamage;
}
