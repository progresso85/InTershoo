using UnityEngine;

public class Trollface : Enemies
{
    [SerializeField]
    private Rigidbody2D rb;

    void Update()
    {
        if (
                gameObject.transform.position.x <= maxPositionX &&
                gameObject.transform.position.x >= minPositionX &&
                gameObject.transform.position.y <= maxPositionY &&
                gameObject.transform.position.y >= minPositionY
           )
        {
            rb.MovePosition(new Vector2(gameObject.transform.position.x + speedX, gameObject.transform.position.y + speedY));
        }
        else
        {
            Destroy(gameObject);
        }

        if((timerBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
        {
            shoot();
            timerBuffer = timer;
        }
    }

    void shoot()
    {
        for(int i = 0; i <= 360; i+=20)
        {
            Instantiate(weapon, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.Euler(0f, 0f, i));
        }
    }
}