using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNode : MonoBehaviour
{
    public enum MovementNodeType
    {
        NORMAL,
        FORK
    }
    public MovementNodeType type;
    public MovementNode nextNode;
    public bool fromFork;

    public MovementNode left;
    public MovementNode right;

    public GameObject EnemiesTrenchObject;
    public GameObject EnemySpawn;

    private void OnEnable()
    {
        if (type != MovementNodeType.NORMAL || fromFork) return;
        if (EnemySpawn == null) { gameObject.SetActive(false); }
        Instantiate(EnemiesTrenchObject, EnemySpawn.transform);
    }

}
