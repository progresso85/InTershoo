using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected GameObject EnemyBullet;

    [SerializeField]
    protected Rigidbody2D rb;

    [SerializeField]
    private AudioClip DamageSoundClip;

    [SerializeField]
    private AudioClip DieSoundClip;

    private AudioSource audioSource;

    protected Fire Fire;

    public Monster()
    {
        Fire = new Fire("simple");
        this.health = 1;
    }

    public Monster(int health, GameObject enemyBullet, string patternType)
    {
        Fire = new Fire(patternType);
        this.health = health;
        EnemyBullet = enemyBullet;
    }

    // Start is called before the first frame update
    protected void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected void Update()
    {

    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.collider.tag == "Player" || collision.collider.tag == "PlayerBullet"))
        {

        }
        else
        {
            Debug.Log("Collision");
            health -= 1;
            audioSource.clip = DamageSoundClip;
            audioSource.Play();

            if (health == 0)
            {
                audioSource.clip = DieSoundClip;
                audioSource.Play();
                audioSource.clip = DamageSoundClip;
                audioSource.Play();
                Destroy(this.gameObject);
            }
        }
        
    }
}
