using UnityEngine;

public abstract class Singletonn<T> : MonoBehaviour
    where T : Component
{
    private static T _instance;
    public static T Instance {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            return _instance;
        }
    }
}

public abstract class SingletonnPersistent<T> : MonoBehaviour
    where T : Component
{
    public static T Instance { get; private set; }
    
    public virtual void Awake ()
    {
        if (Instance == null) {
            Instance = this as T;
            DontDestroyOnLoad (this);
        } else {
            Destroy (gameObject);
        }
    }
}
