using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//泛型模式（避免每新创建一个类都要重复的写单例代码）
public class UnitySingle<T> : MonoBehaviour where T : UnitySingle<T>, new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();

                if (instance == null)
                {
                    instance = new GameObject("Singleton of " + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                }
                else
                {
                    instance.gameObject.name = "Singleton of " + typeof(T).ToString();
                }

                instance.Init();
                GameObject.DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
        set => instance = value;
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            instance.gameObject.name = "Singleton of " + typeof(T).ToString();
            instance.Init();
            GameObject.DontDestroyOnLoad(instance.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }


    public virtual void Init()
    {

    }
}