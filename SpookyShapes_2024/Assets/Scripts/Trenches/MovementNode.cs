using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNode : MonoBehaviour
{
    public enum MovementNodeType
    {
        NORMAL,
        PATH
    }

    public MovementNode nextNode;

}
