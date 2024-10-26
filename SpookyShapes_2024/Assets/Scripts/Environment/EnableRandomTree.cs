using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRandomTree : MonoBehaviour
{
    [SerializeField] List<GameObject> trees;

    private void Start()
    {
        trees[Random.Range(0, trees.Count)].SetActive(true);
    }
}
