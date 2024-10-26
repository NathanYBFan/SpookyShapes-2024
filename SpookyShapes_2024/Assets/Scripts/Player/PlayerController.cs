using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : EntityHP
{
    [SerializeField] Rigidbody playerBody;
    [SerializeField] Transform playerTransform;
    public float playerSpeed;
    int nodesPassed;
    public MovementNode currentNode;
    bool forkChoiceMade;

    public PLAYER_MOVEMENT_STATE movementState;
    public PLAYER_PATH_STATE pathState;
    public enum PLAYER_PATH_STATE
    {
        PATH,
        FORK,
        FORK_LEFT,
        FORK_RIGHT
    }

    public enum PLAYER_MOVEMENT_STATE
    {
        MOVING,
        COMBAT
    }

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
        GameManager.Instance.MainPlayer = instance.transform.parent.gameObject;
    }

    private void Update()
    {
        if (GameManager.stateMachine.GetCurrentState() != GameManager.stateMachine.travelState) return;

        if (movementState == PLAYER_MOVEMENT_STATE.MOVING)
        {
            if (currentNode != null && currentNode.type == MovementNode.MovementNodeType.NORMAL && pathState == PLAYER_PATH_STATE.PATH && (Input.GetKey(KeyCode.UpArrow)))
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, currentNode.transform.position, playerSpeed * Time.deltaTime);
            }
            else if (currentNode != null && currentNode.type == MovementNode.MovementNodeType.NORMAL && pathState != PLAYER_PATH_STATE.PATH)
            {
                if ((pathState == PLAYER_PATH_STATE.FORK_LEFT && Input.GetKey(KeyCode.LeftArrow)) || (pathState == PLAYER_PATH_STATE.FORK_RIGHT && Input.GetKey(KeyCode.RightArrow)))
                {
                    playerTransform.position = Vector3.MoveTowards(playerTransform.position, currentNode.transform.position, playerSpeed * Time.deltaTime);
                }
            }
            else if (currentNode != null  && currentNode.type == MovementNode.MovementNodeType.FORK) 
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    forkChoiceMade = true;
                    currentNode = currentNode.left;
                    ChangePathState(PLAYER_PATH_STATE.FORK_LEFT);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    forkChoiceMade = true;
                    currentNode = currentNode.right;
                    ChangePathState(PLAYER_PATH_STATE.FORK_RIGHT);
                }
                if (forkChoiceMade) 
                {
                    forkChoiceMade = false;
                    TrenchSpawner.Instance.TrenchPathChosen(pathState == PLAYER_PATH_STATE.FORK_LEFT ? true : false);
                }

            }
        }
    }

    public void ChangeMovementState(PLAYER_MOVEMENT_STATE newState)
    {
        movementState = newState;
    }

    public void ChangePathState(PLAYER_PATH_STATE newState)
    {
        pathState = newState;
    }

    private void FixedUpdate()
    {
        if (currentNode != null && Vector3.Distance(playerTransform.position, currentNode.transform.position) < 2)
        {
            currentNode = currentNode.nextNode;
            nodesPassed++;
            TrenchSpawner.Instance.NodePassed();
            if (currentNode.type == MovementNode.MovementNodeType.NORMAL)
            {
                ChangePathState(PLAYER_PATH_STATE.PATH);
            }
            else if (currentNode.type == MovementNode.MovementNodeType.FORK)
            {
                ChangePathState(PLAYER_PATH_STATE.FORK);
            }
        }
    }
}
