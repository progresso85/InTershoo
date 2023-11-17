using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject Trollface;
    [SerializeField]
    GameObject Jason;
    [SerializeField]
    GameObject Sagume;

    public void SpawnTrollface(float x, float y, int health, float maxX, float maxY, float minX, float minY, float speedX, float speedY, int timer)
    {
        Trollface enemy = Instantiate(Trollface, new Vector2(x, y), Quaternion.identity).GetComponent<Trollface>();
        enemy.setHealth(health);

        enemy.setSpeedX(speedX);
        enemy.setSpeedY(speedY);

        enemy.setMaxPositionX(maxX); enemy.setMaxPositionY(maxY);
        enemy.setMinPositionX(minX); enemy.setMinPositionY(minY);

        enemy.setTimer(timer);
    }

    public void SpawnJason(float x, float y, int health, float maxX, float maxY, float minX, float minY, float speedX, float speedY, int timer)
    {
        Jason enemy = Instantiate(Jason, new Vector2(x, y), Quaternion.identity).GetComponent<Jason>();
        enemy.setHealth(health);

        enemy.setSpeedX(speedX);
        enemy.setSpeedY(speedY);

        enemy.setMaxPositionX(maxX); enemy.setMaxPositionY(maxY);
        enemy.setMinPositionX(minX); enemy.setMinPositionY(minY);

        enemy.setTimer(timer);
    }

    public void SpawnSagume()
    {
        Instantiate(Sagume, new Vector2(0, 0), Quaternion.identity);
    }

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            // SpawnTrollface(-5, 5, 5, );
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            // SpawnJason(5, 5);
        }
    }
}