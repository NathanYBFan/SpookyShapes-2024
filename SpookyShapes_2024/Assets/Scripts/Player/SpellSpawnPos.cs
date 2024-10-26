using UnityEngine;

public class SpellSpawnPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SpellSpawnPosGO = this.gameObject;
    }

}
