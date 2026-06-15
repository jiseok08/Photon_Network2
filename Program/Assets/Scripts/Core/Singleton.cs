using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance; // 동적할당 할 변수

    public static Singleton Instance { get { return instance; } } // 참조형 변수

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }       
    }

    public void Call()
    {
        Debug.Log("Call");
    }
}
