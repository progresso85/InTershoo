using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 movement;
    private Vector2 position;
    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private AudioClip shotSoundClip;

    [SerializeField]
    private bool invicible;

    [SerializeField]
    private float volume = 1f;

    // number of shot/second
    [SerializeField]
    private float shotsPerMinute;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movement = Vector2.zero;
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.collider.tag == "Wall" || collision.collider.tag == "PlayerBullet"))
        {
            if(!invicible)
            Destroy(gameObject);
        }
    }

    private void ShootAutoAim()
    {
        // Il faudra globalise �a pour l'ennemi le plus proche
        GameObject boss = GameObject.Find("Boss");

        if (boss != null)
        {
            // sqrt( (x2 - x1 )� + (...)� )
            float distanceToTheBoss = Mathf.Sqrt(Mathf.Pow(boss.transform.position.x - gameObject.transform.position.x, 2) + Mathf.Pow(boss.transform.position.y - gameObject.transform.position.y, 2));
            float horizontalBoss = Mathf.Sqrt(Mathf.Pow(boss.transform.position.x - gameObject.transform.position.x, 2) + Mathf.Pow(boss.transform.position.y - boss.transform.position.y, 2));

            if(gameObject.transform.position.y > boss.transform.position.y)
            {
                horizontalBoss *= -1;
            }

            float angleProjectile = Mathf.Rad2Deg * Mathf.Asin(horizontalBoss/distanceToTheBoss);

            Debug.Log("Distance : " + distanceToTheBoss);
            Debug.Log("Distance H : " + horizontalBoss);
            Debug.Log("Angle : " + angleProjectile);

            if (gameObject.transform.position.x < boss.transform.position.x)
            {
                angleProjectile *= -1;
            }
            if (gameObject.transform.position.y > boss.transform.position.y)
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

        if (Keyboard.current.aKey.isPressed)
        { // X -
            movement.x -= speed;
            position = rb.position;
        }

        if (Keyboard.current.sKey.isPressed)
        { // Y -
            movement.y -= speed;
            position = rb.position;
        }

        if (Keyboard.current.dKey.isPressed)
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
}
