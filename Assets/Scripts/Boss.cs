using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    private Vector2 finalPosition = new Vector2(0, 6);
    private float cooldownTimer;
    private int currentHealthbar;
    private int health = 100;
    private int healthBarNumber = 2;
    private readonly float cooldown = 5;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private TextInput textInput;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(health);
        currentHealthbar = healthBarNumber;
        textInput.SetText(currentHealthbar.ToString());
        gameObject.transform.position = new Vector2(0, 12);
        Debug.Log("Boss has spawned");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > 6)
        {
            rb.MovePosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f));
        }
        Shoot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health > 0)
        {
            health--;
            healthBar.setHealth(health);
        }
        else if (health < 1 && healthBarNumber > 0)
        {
            healthBarNumber--;
            currentHealthbar = healthBarNumber;
            textInput.SetText(currentHealthbar.ToString());
            health = 100;
            healthBar.setHealth(health);

            Debug.Log("Boss lost a healthbar and now have " + currentHealthbar + "healthbar");
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
