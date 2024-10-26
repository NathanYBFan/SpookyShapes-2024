using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning("Referenced instance is not valid, check if it exists in editor and if everything was set up properly. Error from Singelton Base");
                return null;
            }
            return instance;
        }
        private set { instance = value; }
    }

    public Event OnInitialized;

    private static T instance;


    public virtual void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);

        else if (instance == null)
            instance = this as T;
    }

    public void Ping()
    {
        Debug.Log("Pinged " + this.GetType().Name);
    }
}
