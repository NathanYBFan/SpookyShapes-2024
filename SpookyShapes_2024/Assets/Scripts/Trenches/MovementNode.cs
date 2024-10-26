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
    public MovementNode left;
    public MovementNode right;

}
