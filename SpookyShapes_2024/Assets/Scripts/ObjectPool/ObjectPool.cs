using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int objectSpawnAmount;
    public GameObject objectToSpawn; 
    List<GameObject> objects = new List<GameObject>();

    private void Start()
    {
        SpawnObjects(objectSpawnAmount);
    }

    private void SpawnObjects(int x)
    {
        for (int i = 0; i < x; i++)
        {
            GameObject obj = Instantiate(objectToSpawn, transform);
            objects.Add(obj);
            obj.SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeSelf)
            {
                objects[i].SetActive(true);
                return objects[i];
            }
        }
        return null;
    }

    public void ReturnObject(GameObject objToReturn)
    {
        if (!objects.Contains(objToReturn)) return;
        objToReturn.SetActive(false);
        objToReturn.transform.position = Vector3.zero;
    }

}
