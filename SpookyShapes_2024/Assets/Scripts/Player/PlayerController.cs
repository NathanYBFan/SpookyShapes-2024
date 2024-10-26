using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityHP
{
    [SerializeField] Rigidbody playerBody;
    [SerializeField] Transform playerTransform;
    public float playerSpeed;
    int nodesPassed;
    public MovementNode currentNode;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
        
    }

    private void Update()
    {
        

        Debug.Log(playerBody.velocity);
        if (currentNode != null && Input.GetKey(KeyCode.W) && playerBody.velocity.z < 10)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, currentNode.transform.position, playerSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (currentNode != null && Vector3.Distance(playerTransform.position, currentNode.transform.position) < 2)
        {
            currentNode = currentNode.nextNode;
            nodesPassed++;
            TrenchSpawner.Instance.NodePassed();
        }
    }
}
