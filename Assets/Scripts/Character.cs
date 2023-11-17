using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private Vector2 movement;
    private Vector2 position;
    private float cooldownInvincibility = 3f;
    private LivesController livesController;
    private UnityEngine.InputSystem.Controls.KeyControl left;
    private UnityEngine.InputSystem.Controls.KeyControl right;

    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private AudioClip shotSoundClip;

    [SerializeField]
    private AudioClip deathSoundClip;

    [SerializeField]
    private AudioClip stageBGM;

    [SerializeField]
    private bool music;

    [SerializeField]
    private bool godMod;

    [SerializeField]
    private float volume = 1f;

    [SerializeField]
    public int lives;

    // number of shot/second
    [SerializeField]
    private float shotsPerMinute;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        left = Keyboard.current.aKey;
        right = Keyboard.current.dKey;
        movement = Vector2.zero;
        livesController.SetLives(lives);
        if (music)
            AudioSource.PlayClipAtPoint(stageBGM, transform.position, volume);
    }

    void Update()
    {
        nextAttackTime -= Time.deltaTime;
        if (nextAttackTime <= 0)
        {
            if (Keyboard.current.spaceKey.isPressed)
            {
                ShootAutoAim();
                Shoot();
                nextAttackTime = (1 / shotsPerMinute);
            }
        }
        if (cooldownInvincibility - Time.deltaTime > 0)
        {
            cooldownInvincibility -= Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
            godMod = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.collider.tag == "Wall" || collision.collider.tag == "PlayerBullet"))
        {
            if(!godMod)
            {
                AudioSource.PlayClipAtPoint(deathSoundClip, transform.position, volume);
                if (lives > 0)
                {
                    lives--;
                    livesController.ReduceLives();
                    transform.position = new Vector2(0, -7);
                    godMod = true;
                    cooldownInvincibility = 3f;
                    gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                }
                else
                {
                    SceneManager.LoadScene(0);
                    Destroy(gameObject);
                }
                
            }
        }
    }

    private void ShootAutoAim()
    {
        // Il faudra globalise �a pour l'ennemi le plus proche
        GameObject ennemy = GameObject.Find("Boss");

        if (ennemy != null)
        {
            // sqrt( (x2 - x1 )� + (y2 - y1)� )
            float distanceToTheBoss = Mathf.Sqrt(Mathf.Pow(ennemy.transform.position.x - gameObject.transform.position.x, 2) + Mathf.Pow(ennemy.transform.position.y - gameObject.transform.position.y, 2));
            float horizontalBoss = Mathf.Sqrt(Mathf.Pow(ennemy.transform.position.x - gameObject.transform.position.x, 2) /* Ce truc est �gale �Ez�ro, on s'en fou + Mathf.Pow(ennemy.transform.position.y - ennemy.transform.position.y, 2) */);

            if(gameObject.transform.position.y > ennemy.transform.position.y)
            {
                horizontalBoss *= -1;
            }

            float angleProjectile = Mathf.Rad2Deg * Mathf.Asin(horizontalBoss/distanceToTheBoss);
            if (gameObject.transform.position.x < ennemy.transform.position.x)
            {
                angleProjectile *= -1;
            }
            if (gameObject.transform.position.y > ennemy.transform.position.y)
            {
                angleProjectile += 180;
            }

            Instantiate(Bullet, rb.position + new Vector2(-0.5f, 0f), Quaternion.Euler(0f, 0f, angleProjectile));
            Instantiate(Bullet, rb.position + new Vector2(0.5f, 0f), Quaternion.Euler(0f, 0f, angleProjectile));
        }
    }

    private void Shoot()    
    {
        for(int i = -10; i <= 10; i += 10)
        {
            Instantiate(Bullet, rb.position + new Vector2(0, 0.5f), Quaternion.Euler(0f, 0f, i));
        }
        AudioSource.PlayClipAtPoint(shotSoundClip, transform.position, volume);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        // sneak to reduce speed

        // do a listener on the key W, on press "input System V2"

        if (Keyboard.current.wKey.isPressed)
        { // Y +
            movement.y += speed;
            position = rb.position;
        }

        if (left.isPressed)
        { // X -
            movement.x -= speed;
            position = rb.position;
        }

        if (Keyboard.current.sKey.isPressed)
        { // Y -
            movement.y -= speed;
            position = rb.position;
        }

        if (right.isPressed)
        { // X +
            movement.x += speed;
            position = rb.position;
        }

        movement.Normalize();
        if(Keyboard.current.shiftKey.isPressed)
        {
            movement *= speed / 2;
        }
        else
        {
            movement *= speed;
        }

        if (movement != null || movement != Vector2.zero) {
            rb.MovePosition(rb.position + movement);
        }
        movement = Vector2.zero;

    }
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float value)
    {
        speed += value;
    }
    public void InvertLeftRight()
    {
        UnityEngine.InputSystem.Controls.KeyControl oldLeft = left;
        left = right;
        right = oldLeft;
    }
    private void Awake()
    {
        // works only if there is only one score (one player game)
        livesController = FindObjectOfType<LivesController>();
    }
}
