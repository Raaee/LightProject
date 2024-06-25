using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    protected static T instance;

    public static bool HasInstance => instance != null;

    public static T TryGetInstance() => HasInstance ? instance : null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                FindAnyObjectByType<T>();
                if (instance == null)
                {
                    var go = new GameObject(typeof(T).Name + " Auto-Generated.");
                }
            }

            return instance;
        }
    }

    /// <summary>
    /// Make sure to call base.Awake() in override if you need awake;
    /// </summary>
    protected virtual void Awake()
    {
        InitilizeSingleton();
    }

    protected virtual void InitilizeSingleton()
    {
        if(!Application.isPlaying) return;

        instance = this as T;
    }
}
