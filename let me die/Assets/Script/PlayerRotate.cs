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
        // Trouver le milieu de l'�cran
        float screenMiddle = Screen.width / 2;

        // V�rifier si la souris est � gauche ou � droite
        bool isMouseOnLeft = Input.mousePosition.x < screenMiddle;

        // Si la souris est � gauche et qu'on fait face � droite, on inverse
        if (isMouseOnLeft && isFacingRight)
        {
            Flip();
        }
        // Si la souris est � droite et qu'on fait face � gauche, on inverse
        else if (!isMouseOnLeft && !isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Inverser la direction
        isFacingRight = !isFacingRight;

        // Appliquer une rotation de 180� ou revenir � 0�
        float yRotation = isFacingRight ? 0f : 180f;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

    }

}
