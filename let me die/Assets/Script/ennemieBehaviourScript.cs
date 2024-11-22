using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemieBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject ennemi;
    public Transform player;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        ennemi.transform.position = Vector2.MoveTowards(ennemi.transform.position, player.transform.position, speed);

        //rb.velocity = new Vector2(-speed, 0f);
    }
}
