using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemieBehaviourScript : MonoBehaviour
{
    public GameObject ennemi;
    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ennemi.transform.position = Vector2.MoveTowards(ennemi.transform.position, player.transform.position, speed);
    }
}
