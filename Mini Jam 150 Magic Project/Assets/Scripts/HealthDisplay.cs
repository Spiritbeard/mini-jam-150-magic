using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private TextMeshProUGUI healthTextMeshPro;
    
    void Start()
    {
        healthTextMeshPro = GetComponent<TextMeshProUGUI>();
        UpdateHealthText(100);
    }

    private void OnEnable()
    {
        PlayerHealthController.OnHealthChange += UpdateHealthText;
    }

    private void OnDisable()
    {
        PlayerHealthController.OnHealthChange -= UpdateHealthText;
    }

    private void UpdateHealthText(int health)
    {
        healthTextMeshPro.text = new string("Health: " + health.ToString());
    }
}
