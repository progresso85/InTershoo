using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Vector2 finalPosition = new Vector2 (0, 6);

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private int health;

    [SerializeField]
    private int healthBar;

    [SerializeField]
    private GameObject Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate (Healthbar, new Vector2(0, 8.5f), Quaternion.identity);


        gameObject.transform.position = new Vector2(0, 12);
        Debug.Log("Boss has spawned");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
