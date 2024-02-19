using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPersistent : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
