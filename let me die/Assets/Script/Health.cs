using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    
    
    public float health, maxHealth;

    [SerializeField]
    public int EnnemiDamage;

    [SerializeField]
    public int Ennemi2Damage;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;




    // Start is called before the first frame update
    void Start()
    {
       maxHealth = health;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            health -= EnnemiDamage;
        }

        if (collision.gameObject.CompareTag("Ennemi2"))
        {
            health -= Ennemi2Damage;
        }
    }




    // Update is called once per frame
    void Update()
    {
        

        if (health < 0)
        {
            
            isDead = true;
        }
        if (isDead == true)
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }



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
