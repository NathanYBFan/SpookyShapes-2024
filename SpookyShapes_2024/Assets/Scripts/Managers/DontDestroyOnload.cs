using UnityEngine;

public class DontDestroyOnload : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
