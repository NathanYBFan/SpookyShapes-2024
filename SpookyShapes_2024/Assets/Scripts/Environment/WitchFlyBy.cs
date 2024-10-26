using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchFlyBy : MonoBehaviour
{
    [SerializeField] GameObject WitchGO;
    [SerializeField] float speed;
    [SerializeField] GameObject StartPos;
    [SerializeField] GameObject EndPos;
    bool willBeActive;
    bool waiting;

    private void Start()
    {
        willBeActive = Random.Range(0, 10) <= 2 ? true : false;
        if (!willBeActive) gameObject.SetActive(false);
        WitchGO.transform.position = StartPos.transform.position;
    }

    private void Update()
    {
        if (waiting) return;
        WitchGO.transform.position = Vector3.MoveTowards(WitchGO.transform.position, EndPos.transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(WitchGO.transform.position, EndPos.transform.position) < 2)
        {
            waiting = true;
            WitchGO.transform.position = StartPos.transform.position;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        waiting = false;
    }



}
