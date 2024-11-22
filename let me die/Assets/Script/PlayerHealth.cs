using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //public float health;
    //public float maxHealth;

    [SerializeField]
    public float health, maxHealth;

    [SerializeField]
    private Image healthBar;
    public Gradient healthgradiant;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;


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

        // Ajuster la largeur de la barre (si n�cessaire)
        healthBar.fillAmount = healthPercentage;
    }

    //Exemple : fonction � appeler quand la vie change
    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    //void TakeDamage(int damage)
    //{
    //    health -= damage;
    //}

    public void InitializeHealth(int healthValue)
    {
        health = healthValue;
        maxHealth = healthValue;
        isDead = false;
        
    }

    public void GetHit(int amount, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        health -= amount;

        if (health > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            Destroy(gameObject);
        }
    }
}
