using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    [SerializeField]
    private Character character;
    [SerializeField]
    private Spawner spawner;

    private List<GameObject> enemies;

    private int step = 0;
    private int timer = 1000, timerBuffer = 0;
    private int mobSummoned = 0;

    private void Start()
    {
        character.SetSpeed(0.15f);
    }

    private void Update()
    {
        switch(step)
        {
            case 0:
                if((timerBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
                {
                    spawner.SpawnJason(-6.3f, 6, 5, 6.3f, 10, -6.3f, 0, 0.2f, 0, 400);
                    spawner.SpawnJason(6.3f, 6, 5, 6.3f, 10, -6.3f, 0, -0.2f, 0, 400);
                    mobSummoned++;
                    timerBuffer = timer;
                }

                if(mobSummoned == 5)
                {
                    mobSummoned = 0;
                    step++;
                }
                break;
            case 1:
                // once
                if(mobSummoned == 0)
                {
                    spawner.SpawnTrollface(0, 8, 20, 6.3f, 10, -6.3f, -8, 0f, -0.01f, 1000);
                    mobSummoned = 1;
                }
                if ((timerBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
                {
                    spawner.SpawnJason(-6.3f, 7, 5, 6.3f, 10, -6.3f, 0, 0.05f, 0, 300);
                    spawner.SpawnJason(6.3f, 7, 5, 6.3f, 10, -6.3f, 0, -0.05f, 0, 300);
                    mobSummoned++;
                    timerBuffer = timer;
                }

                if (mobSummoned == 5)
                {
                    step++;
                    mobSummoned = 0;
                }
                break;
            case 2:
                // once
                if (mobSummoned == 0)
                {
                    spawner.SpawnTrollface(-6.3f, -7, 50, 6.3f, 10, -6.3f, -8, 0.01f, 0, 750);
                    spawner.SpawnTrollface(6.3f, -7, 50, 6.3f, 10, -6.3f, -8, -0.01f, 0, 750);
                    mobSummoned = 1;
                }
                if ((timerBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
                {
                    spawner.SpawnJason(6.3f, 1, 5, 6.3f, 10, -6.3f, -8, -0.2f, 0, 300);
                    spawner.SpawnJason(6.3f, -1, 5, 6.3f, 10, -6.3f, -8, -0.2f, 0, 300);
                    mobSummoned++;
                    timerBuffer = timer;
                }

                if (mobSummoned == 5)
                {
                    mobSummoned = 0;
                    timerBuffer = 2000;
                    step++;
                }
                break;
            case 3:
                if (mobSummoned == 0)
                {
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                    {
                        if ((timerBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
                        {
                            spawner.SpawnSagume();
                            mobSummoned++;
                            timerBuffer = timer;
                        }
                    }
                }
                else
                {

                }
                break;
            default: break;
        }
    }
}