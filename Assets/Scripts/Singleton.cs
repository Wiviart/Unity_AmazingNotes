using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance) return instance;
            instance = FindObjectOfType<T>();
            if (instance) return instance;
            var obj = new GameObject
            {
                name = typeof(T).Name
            };
            instance = obj.AddComponent<T>();

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}