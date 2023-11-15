using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Vector2 finalPosition = new Vector2(0, 6);
    private float cooldownTimer;
    private int originalHealthbar;
    private int currentHealthbar;
    private int health = 100;
    private int healthBar = 1;
    private float cooldown = 5;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        originalHealthbar = healthBar;
        currentHealthbar = healthBar;
        gameObject.transform.position = new Vector2(0, 12);
        Debug.Log("Boss has spawned");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > 6)
        {
            rb.MovePosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f));
            Debug.Log(gameObject.transform.position.y);
        }
        Shoot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health > 0)
        {
            health--;
            Debug.Log("Boss have " + health + "health now");
        }
        else if (health == 0 && healthBar > 0)
        {
            originalHealthbar = healthBar;
            healthBar -= 1;
            currentHealthbar = healthBar;
            health = 100;
            Debug.Log("Boss lost a healthbar and now have " + healthBar + "healthbar");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("You killed Boss");
        }
    }

    void Shoot()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);


    }
}
