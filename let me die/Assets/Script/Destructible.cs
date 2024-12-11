using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destructible : MonoBehaviour
{
    public int scoreValue = 10; // Valeur à ajouter au score lors de la destruction

    private void OnDestroy()
    {
        // Augmente le score quand l'objet est détruit
        MoneyManager.AddScore(scoreValue);
    }

    public void DestroyObject()
    {
        // Détruit l'objet
        Destroy(gameObject);
    }
}
