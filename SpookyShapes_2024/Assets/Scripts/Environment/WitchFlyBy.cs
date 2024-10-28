using System.Collections;
using UnityEngine;

public class WitchFlyBy : MonoBehaviour
{
    [SerializeField] GameObject WitchGO;
    [SerializeField] float speed;
    [SerializeField] GameObject StartPos;
    [SerializeField] GameObject EndPos;
    [SerializeField] TrailRenderer trailRenderer;
    [SerializeField] bool Rotate;
    [SerializeField] GameObject RotatePivot;
    bool willBeActive;
    bool waiting;

    private void Start()
    {
        willBeActive = Random.Range(0, 10) <= 4 ? true : false;
        if (!willBeActive) gameObject.SetActive(false);
        //WitchGO.transform.position = StartPos.transform.position;
        if (Rotate)
        {
            speed = Random.Range(speed * 0.75f, speed * 1.25f);
            WitchGO.transform.parent = StartPos.transform;
            WitchGO.transform.localPosition = Vector3.zero;
        }
    }

    private void Update()
    {
        if (waiting) return;
        if (!Rotate)
        {
            WitchGO.transform.position = Vector3.MoveTowards(WitchGO.transform.position, EndPos.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(WitchGO.transform.position, EndPos.transform.position) < 2)
            {
                if (trailRenderer != null) trailRenderer.enabled = false;
                waiting = true;
                WitchGO.transform.position = StartPos.transform.position;
                StartCoroutine(Wait());
                if (trailRenderer != null) trailRenderer.enabled = true;
            }
        }
        else
        {
            RotatePivot.transform.Rotate(0, 0, (speed * Time.deltaTime));
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        waiting = false;
    }



}
