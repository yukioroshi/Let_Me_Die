using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{

    // Orientation initiale (droite)
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlipBasedOnMouse();
    }

    void FlipBasedOnMouse()
    {
        // Trouver le milieu de l'écran
        float screenMiddle = Screen.width / 2;

        // Vérifier si la souris est à gauche ou à droite
        bool isMouseOnLeft = Input.mousePosition.x < screenMiddle;

        // Si la souris est à gauche et qu'on fait face à droite, on inverse
        if (isMouseOnLeft && isFacingRight)
        {
            Flip();
        }
        // Si la souris est à droite et qu'on fait face à gauche, on inverse
        else if (!isMouseOnLeft && !isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Inverser la direction
        isFacingRight = !isFacingRight;

        // Inverser le scale en y (mirroir horizontal)
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }

}
