using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourcesController : MonoBehaviour
{

    [SerializeField] private int resources;
    public static event Action<int> OnResourcesChange;

    private void OnEnable()
    {
        resources = 0;
    }

    void IncrementResources(int resourcesChange)
    {
        resources += resourcesChange;

        OnResourcesChange?.Invoke(resources);
    }
}
