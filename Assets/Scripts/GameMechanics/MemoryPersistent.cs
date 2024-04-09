using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPersistent : MonoBehaviour
{
    [SerializeField] private bool isEditorOnly = false;
    void Awake()
    {
        if (isEditorOnly && !Application.isEditor)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
