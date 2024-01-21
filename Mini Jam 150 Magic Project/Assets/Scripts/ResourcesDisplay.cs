using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesDisplay : MonoBehaviour
{
    private TextMeshProUGUI resourcesTextMeshPro;
    
    void Start()
    {
        resourcesTextMeshPro = GetComponent<TextMeshProUGUI>();
        UpdateResourcesText(0);
    }

    private void OnEnable()
    {
        PlayerResourcesController.OnResourcesChange += UpdateResourcesText;
    }

    private void OnDisable()
    {
        PlayerResourcesController.OnResourcesChange -= UpdateResourcesText;
    }

    private void UpdateResourcesText(int resources)
    {
        resourcesTextMeshPro.text = new string("Resources: " + resources.ToString());
    }
}
