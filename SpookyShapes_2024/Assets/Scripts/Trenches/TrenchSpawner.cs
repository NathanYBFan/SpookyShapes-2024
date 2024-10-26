using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrenchSpawner : MonoBehaviour
{
    public static TrenchSpawner Instance;


    [SerializeField] ObjectPool trenchPool_straight;
    [SerializeField] ObjectPool trenchPool_fork;

    [SerializeField] int maxTrenchesAtOnce;
    [SerializeField] int trenchPlaceSpacing;
    public int trenchesPlaced;
    public int trenchesPlacedUntilFork = 6;
    int currentDistance = 0; //where to spawn next node
    public List<MovementNode> movementNodes = new List<MovementNode>();
    private MovementNode previousNode;
    public MovementNode currentNode;


    private void Awake()
    {
        Instance = this;
    }

    private void SpawnNode()
    {
        GameObject newTrench;
        float distance = currentDistance;
        trenchesPlaced++;
        
        if (trenchesPlaced <= trenchesPlacedUntilFork)
            newTrench = trenchPool_straight.GetObject();
        else
        {
            newTrench = trenchPool_fork.GetObject();
            trenchesPlaced = 0;
        }

        if (newTrench == null ) { return; }

        if (previousNode == null)
            newTrench.transform.position = new Vector3(0, 0, currentDistance);
        else
            newTrench.transform.position = new Vector3(currentNode.transform.position.x, 0, currentDistance);
        
        

        MovementNode moveNode = newTrench.GetComponentInChildren<MovementNode>();

        currentDistance += moveNode.type == MovementNode.MovementNodeType.NORMAL ? trenchPlaceSpacing : trenchPlaceSpacing*2;

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
        
        SpawnMoreTrenches(trenchesPlacedUntilFork);   
    }

    public void NodePassed()
    {
        //SpawnMoreTrenches(1);
        RemoveMoreTrenches(1);
    }

    public void TrenchPathChosen(bool LEFT)
    {
        if (LEFT) 
        { 
            currentNode = currentNode.left;
        }
        else
        {
            currentNode = currentNode.right;
        }
        SpawnMoreTrenches(trenchesPlacedUntilFork+1);

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
            if (toGo.type == MovementNode.MovementNodeType.NORMAL)
                trenchPool_straight.ReturnObject(toGo.gameObject);
            else
                trenchPool_fork.ReturnObject(toGo.gameObject);
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
