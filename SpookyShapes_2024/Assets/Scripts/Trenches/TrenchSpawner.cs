using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrenchSpawner : MonoBehaviour
{
    public static TrenchSpawner Instance;


    [SerializeField] GameObject TrenchPrefab_Straight;
    [SerializeField] GameObject TrenchPrefab_Fork;

    [SerializeField] int maxTrenchesAtOnce;
    [SerializeField] int trenchPlaceSpacing;
    int currentDistance = 0; //where to spawn next node
    public List<MovementNode> movementNodes = new List<MovementNode>();
    private MovementNode previousNode;
    private MovementNode currentNode;


    private void Awake()
    {
        Instance = this;
    }

    private void SpawnNode()
    {
        GameObject newTrench;
        float rand = Random.Range(0, 10);

        if (rand <= 8)
            newTrench = Instantiate(TrenchPrefab_Straight, transform);
        else
            newTrench = Instantiate(TrenchPrefab_Straight, transform);

        if (previousNode == null)
            newTrench.transform.position = new Vector3(0, 0, currentDistance);
        else
            newTrench.transform.position = new Vector3(previousNode.transform.position.x, 0, currentDistance);
        
        currentDistance += trenchPlaceSpacing;

        MovementNode moveNode = newTrench.GetComponentInChildren<MovementNode>();
        
        if (previousNode != null) currentNode.nextNode = moveNode;
        else 
        { 
            previousNode = moveNode;
            PlayerController.instance.currentNode = moveNode;
        }
        
        previousNode.nextNode = currentNode;
        previousNode = currentNode;
        currentNode = moveNode;
        movementNodes.Add(moveNode);
    }

    private void Start()
    {
        SpawnNode();
        
        SpawnMoreTrenches(maxTrenchesAtOnce);   
    }

    public void NodePassed()
    {
        SpawnMoreTrenches(1);
        RemoveMoreTrenches(1);
    }

    private void SpawnMoreTrenches(int x)
    {
        StartCoroutine(SpawnTrenches(x));
    }

    private void RemoveMoreTrenches(int x)
    {
        StartCoroutine(RemoveTrenches(x));
    }

    IEnumerator RemoveTrenches(int x)
    {
        for (int i = 0; i < x; i++)
        {
            MovementNode toGo = movementNodes[0];
            movementNodes.RemoveAt(0);
            Destroy(toGo.gameObject);
            yield return null;
        }
        yield return null;
    }

    IEnumerator SpawnTrenches(int x)
    {
        for (int i = 0; i < x; i++)
        {
            SpawnNode();
            yield return null;
        }
        yield return null;
    }
}
