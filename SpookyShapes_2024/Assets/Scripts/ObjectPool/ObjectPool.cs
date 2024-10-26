using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    List<GameObject> objects;

    public GameObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeSelf) return objects[i];
            
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
