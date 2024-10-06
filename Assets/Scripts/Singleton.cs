using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            //If the instance is null, set the instance to this current class
            //otherwise if its not == we want to destroy the gameObject
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            else if (instance != null)
            {
                Destroy(FindObjectOfType<T>());
            }

            //DontDestroyOnLoad(FindObjectOfType<T>());
            return instance;
        }
    }
}