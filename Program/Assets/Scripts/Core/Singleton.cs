using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance; // 동적할당 할 변수

    public static T Instance  // 참조형 변수 (함수?)
    {        
        get 
        { 
            if (instance == null)
            {
                instance = (T)FindAnyObjectByType(typeof(T));

                if (instance == null)
                {
                    GameObject clone = new GameObject(typeof(T).Name);

                    instance = clone.AddComponent<T>();
                }
            }

            return instance; 
        } 
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
