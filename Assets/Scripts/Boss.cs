using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Vector2 finalPosition = new Vector2(0, 6);
    private int currentHealthbar;
    [SerializeField]
    private int health = 500;
    private int currentHealth = 500;
    private int healthBarNumber = 2;

    private int burstCount; // number of "wave" the boss will fire
    private int burstCooldown; // time between each fire of the burst
    private int reloadCooldown; // time to reload and fire an another burst
    // buffer memory
    private int burstCountBuffer = 0;
    private int burstCooldownBuffer = 0;
    private int reloadCooldownBuffer = 0;

    private int addRotation = 0;

    private float teleportationTimer = 1;
    private Vector2 Original_coords;
    private List<Vector2> list_of_coords;

    private int actualBossPointNumber;

    private ScoreController scoreController;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private Character character;

    [SerializeField]
    private TextInput textInput;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject weapon;

    [SerializeField] 
    private AudioClip healthBarOma;

    [SerializeField] 
    private AudioClip healthBarNani;

    [SerializeField]
    private AudioClip dieSoundAudio;

    [SerializeField]
    private AudioClip damageSoundAudio;

    [SerializeField]
    private AudioClip bossShotSoundAudio;

    [SerializeField]
    private int bossHitPointsValue;

    [SerializeField]
    private int bossRemoveABarPointsValue;

    [SerializeField]
    private int bossKillPointsValue;

    [SerializeField]
    private float volume;

    [SerializeField]
    private float shotsvolume;


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
        character.SetSpeed(character.GetSpeed()*1.5f);

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
            if (currentHealthbar == 2)
            {
                ShootPatternTreeShot();
            }
            if(currentHealthbar == 1)
            {
                ShootPatternWave();
            }
            if(currentHealthbar == 0)
            {
                ShootPatternCircle();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AllocateHitBossScore();
        AudioSource.PlayClipAtPoint(damageSoundAudio, transform.position, volume);
        if (currentHealth > 0)
        {
            currentHealth--;
            healthBar.setHealth(currentHealth);
        }
        else if (currentHealth < 1 && healthBarNumber > 0)
        {
            character.InvertLeftRight();
            AllocateRemoveABarBossScore();
            
            healthBarNumber--;
            if (healthBarNumber == 1)
            {
                AudioSource.PlayClipAtPoint(healthBarNani, transform.position, volume);
            }
            else
            {
                AudioSource.PlayClipAtPoint(healthBarOma, transform.position, volume);
            }
            currentHealthbar = healthBarNumber;
            textInput.SetText(currentHealthbar.ToString());
            currentHealth = health;
            healthBar.setHealth(currentHealth);
        }
        else
        {
            AllocateRemoveABarBossScore();
            AllocateKillBossScore();
            Destroy(gameObject);
        }
    }
    void ShootPatternTreeShot()
    {
        burstCount = 4;
        burstCooldown = 100;
        reloadCooldown = 2000;

        if (burstCountBuffer < burstCount)
        {
            if ((burstCooldownBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
            {
                burstCountBuffer++;
                burstCooldownBuffer = burstCooldown;
                // the value of i the diffence of angle between then
                for(int i = -20; i <= 20; i += 20)
                {
                    AudioSource.PlayClipAtPoint(bossShotSoundAudio, transform.position, shotsvolume);
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
    void ShootPatternWave()
    {
        burstCount = 10;
        burstCooldown = 100;
        reloadCooldown = 1000;

        if (burstCountBuffer < burstCount)
        {
            if ((burstCooldownBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
            {
                burstCountBuffer++;
                int angle = burstCountBuffer * 10;
                angle -= burstCooldown / 2;
                burstCooldownBuffer = burstCooldown;
                // the value of i the diffence of angle between then
                for (int i = -10; i <= 10; i += 20)
                {
                    AudioSource.PlayClipAtPoint(bossShotSoundAudio, transform.position, shotsvolume);
                    Instantiate(weapon, gameObject.transform.position, Quaternion.Euler(0f, 0f, angle + i));
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
    void ShootPatternCircle()
    {
        actualBossPointNumber = 0;
        list_of_coords = new List<Vector2>
        {
            new Vector2(0,7)
        };

        burstCount = 1;
        burstCooldown = 0;
        reloadCooldown = 100;


        if (burstCountBuffer < burstCount)
        {
            if ((burstCooldownBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
            {
                burstCountBuffer++;
                burstCooldownBuffer = burstCooldown;
                // the value of i the diffence of angle between then
                for (int i = 0; i <= 360; i += 36)
                {
                    AudioSource.PlayClipAtPoint(bossShotSoundAudio, transform.position, shotsvolume);
                    Instantiate(weapon, gameObject.transform.position, Quaternion.Euler(0f, 0f, i + addRotation));
                    addRotation += 1;
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

    void teleportToCoords(Vector2 coords)
    {
            // teleportation !!!
            gameObject.transform.position = coords;
            teleportationTimer = 0.01f;
    }

    private void Awake()
    {
        // works only if there is only one score (one player game)
        scoreController = FindObjectOfType<ScoreController>();
    }

    // three methods to allocate score to the player when he hit the boss or remove a bar of health or kill him.
    public void AllocateHitBossScore()
    {
        scoreController.AddScore(bossHitPointsValue);
    }
    public void AllocateRemoveABarBossScore()
    {
        scoreController.AddScore(bossRemoveABarPointsValue);
    }
    public void AllocateKillBossScore()
    {
        scoreController.AddScore(bossKillPointsValue);
    }
}
