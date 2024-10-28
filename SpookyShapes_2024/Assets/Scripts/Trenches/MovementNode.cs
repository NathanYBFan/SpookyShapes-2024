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

    public GameObject EnemiesTrenchObject_prefab;
    public GameObject EnemiesTrenchObject;
    public GameObject EnemySpawn;

    private void OnEnable()
    {
        if (type != MovementNodeType.NORMAL || fromFork) return;
        if (EnemySpawn == null) { gameObject.SetActive(false); }
        if (EnemySpawn.transform.childCount > 0) return;
        EnemiesTrenchObject = Instantiate(EnemiesTrenchObject_prefab, EnemySpawn.transform);
    }

    private void OnDisable()
    {
        if (type != MovementNodeType.NORMAL || fromFork) return;
        if (EnemySpawn.transform.childCount > 0)
            Destroy(EnemiesTrenchObject);
    }

}
