using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    

    [SerializeField]
    private Image healthBar;

    public Gradient healthgradiant;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        UpdateHealthBar();

    }

    void UpdateHealthBar()
    {
        // Calculer la proportion de vie restante
        float healthPercentage = Mathf.Clamp01(health / maxHealth);

        // Appliquer la couleur du gradient
        healthBar.color = healthgradiant.Evaluate(healthPercentage);

        // Ajuster la largeur de la barre (si nécessaire)
        healthBar.fillAmount = healthPercentage;
    }

    // Exemple : fonction à appeler quand la vie change
    public void SetHealth(float newHealth)
    {
        health = newHealth;
        UpdateHealthBar();
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
