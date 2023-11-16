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

    private float teleportationTimer = 1;
    private Vector2 Original_coords;
    private List<Vector2> list_of_coords;

    private int actualBossPointNumber;

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
        // get original position of the boss
        Original_coords = gameObject.transform.position;
        healthBar.setMaxHealth(health);
        currentHealthbar = healthBarNumber;
        textInput.SetText(currentHealthbar.ToString());
        gameObject.transform.position = new Vector2(0, 6);
        Debug.Log("Boss has spawned");
        Debug.Log("Boss coords are " + Original_coords);
        actualBossPointNumber = 0;
        list_of_coords = new List<Vector2> { Original_coords, new Vector2(0, -2), Original_coords, new Vector2(4,2), new(6,-2)};
    }

    // Update is called once per frame
    void Update()
    {
            
        Shoot();
        teleportationPatern2();
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
    void teleportationPatern1()
        {       

        // where am i ?
        Vector2 currentPos = gameObject.transform.position;

        if ((currentPos == Original_coords) || (currentPos == Original_coords + new Vector2(2, -2)))
        {   
            finalPosition = Original_coords + new Vector2(2, 2);
        }else if (currentPos == Original_coords + new Vector2(2, 2))
        {
            finalPosition = Original_coords + new Vector2(-2, 2);
        }else if (currentPos == Original_coords + new Vector2(-2, 2))
        {
            finalPosition = Original_coords + new Vector2(-2, -2);
        }else if (currentPos == Original_coords + new Vector2(-2, -2))
        {
            finalPosition = Original_coords + new Vector2(2, -2);
        }
        teleportToCoords(finalPosition);
    }
    void teleportationPatern2()
    {
        
        teleportationTimer -= Time.deltaTime;
        if (teleportationTimer < 0)
        {
            var aimed_position = list_of_coords[actualBossPointNumber];
            Vector2 currentPos = gameObject.transform.position;
            // if not at the right position
            Debug.Log("Aimedpoint is " + actualBossPointNumber);
            Debug.Log("Boss is at " + currentPos);
            Debug.Log("Aimed position is " + aimed_position);
            Debug.Log("Distance in x is " + Mathf.Abs(currentPos.x - aimed_position.x));


            //if too far from the aimed position x
            if (Mathf.Abs(currentPos.x - aimed_position.x) > 0.05f)
            {
                // if need to go left or right
                if ((aimed_position.x - currentPos.x) < 0.05f)
                {   
                    Debug.Log(aimed_position.x);
                    teleportToCoords(currentPos + new Vector2(-0.1f, 0));
                }
                else
                {
                    teleportToCoords(currentPos + new Vector2(0.1f, 0));
                }
            }
            // if too far from the aimed position y
            else if (Mathf.Abs(currentPos.y - aimed_position.y) > 0.05f)
            {
                // if need to go up or down
                if ((aimed_position.y - currentPos.y) < 0.05f)
                {
                    teleportToCoords(currentPos + new Vector2(0, -0.1f));
                }
                else
                {   
                    teleportToCoords(currentPos + new Vector2(0, +0.1f));
                }
            } 
            // he is at the right position
            else
            { // go to the next point
                Debug.Log("Boss is at the right position");
                actualBossPointNumber++;
            }
            if (actualBossPointNumber > (list_of_coords.Count - 1))
            {
                Debug.Log("End of the list");
                // go back to the first point
                actualBossPointNumber = 0;
            }

        }
    }




    // teleporter to (x,y) coords
    // wait for 5 seconds => timer1
    // teleport back to original position
    // wait for 5 seconds => timer2
    // repeat

    void teleportToCoords(Vector2 coords)
    {
            // teleportation !!!
            gameObject.transform.position = coords;
            teleportationTimer = 0.01f;
    }
}
