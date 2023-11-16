using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    private Vector2 finalPosition = new Vector2(0, 6);
    private int currentHealthbar;
    private int health = 100;
    private int healthBarNumber = 2;

    private int burstCount = 4; // number of "wave" the boss will fire
    private int burstCooldown = 100; // time between each fire of the burst
    private int reloadCooldown = 2000; // time to reload and fire an another burst
    // buffer memory
    private int burstCountBuffer = 0;
    private int burstCooldownBuffer = 0;
    private int reloadCooldownBuffer = 0;

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
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        // get original position of the boss
        Original_coords = gameObject.transform.position;
        healthBar.setMaxHealth(health);
        currentHealthbar = healthBarNumber;
        textInput.SetText(currentHealthbar.ToString());
        gameObject.transform.position = new Vector2(0, 6);
        actualBossPointNumber = 0;

        // patern =
        list_of_coords = new List<Vector2> { 
            Original_coords,
            new Vector2(0, -2),
            Original_coords,
            new Vector2(4,2),
            Original_coords,
            new Vector2(-3,6),
            Original_coords,
            new Vector2(0,6),
            Original_coords,
            new Vector2(0,0),
            Original_coords,
            new Vector2(0,6),
            Original_coords,
            new Vector2(-4,6),
            new Vector2(4,6),
        };
    }

    // Update is called once per frame
    void Update()
    {
        teleportationPatern2();

        if((reloadCooldownBuffer = reloadCooldownBuffer - (int)(Time.deltaTime * 1000)) <= 0)
        {
            // reloadCooldownBuffer will be reset in shoot when the burst is finish
            if(currentHealthbar == 2)
            {
                ShootPattern1();
            }
            if(currentHealthbar == 1)
            {
                ShootPattern1();
            }
            if(currentHealthbar == 0)
            {
                ShootPattern1 ();
            }
        }
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
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("You killed Boss");
        }
    }

    void ShootPattern1()
    {
        if(burstCountBuffer < burstCount)
        {
            if ((burstCooldownBuffer = burstCooldownBuffer - (int)(Time.deltaTime * 1000)) <= 0)
            {
                burstCountBuffer++;
                burstCooldownBuffer = burstCooldown;
                // the value of i the diffence of angle between then
                for(int i = -20; i <= 20; i += 20)
                {
                    Instantiate(weapon, gameObject.transform.position, Quaternion.Euler(0f, 0f, i));
                }
            }
        }
        else
        {
            reloadCooldownBuffer = reloadCooldown;
            burstCountBuffer = 0;
            burstCooldownBuffer = 0;
        }
    }

    void teleportationPatern2()
    {
        teleportationTimer -= Time.deltaTime;
        if (teleportationTimer < 0)
        {
            var aimed_position = list_of_coords[actualBossPointNumber];
            Vector2 currentPos = gameObject.transform.position;
            // if not at the right position
            //if too far from the aimed position x
            if (Mathf.Abs(currentPos.x - aimed_position.x) > 0.05f)
            {
                // if need to go left or right
                if ((aimed_position.x - currentPos.x) < 0.05f)
                {   
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
                actualBossPointNumber++;
            }
            if (actualBossPointNumber > (list_of_coords.Count - 1))
            {
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
