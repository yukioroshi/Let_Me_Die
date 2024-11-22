using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{

    [SerializeField]
    public PlayerHealth Health;

    [SerializeField]
    private Image healthBar;
    public Gradient healthgradiant;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Calculer la proportion de vie restante
        float healthPercentage = Mathf.Clamp01(Health.health / Health.maxHealth);

        // Appliquer la couleur du gradient
        healthBar.color = healthgradiant.Evaluate(healthPercentage);

        // Ajuster la largeur de la barre (si nécessaire)
        healthBar.fillAmount = healthPercentage;
    }
}
