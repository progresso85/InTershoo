using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject Cyclops;
    [SerializeField]
    GameObject Skull;

    void SpawnCyclops(int x, int y)
    {
        Instantiate(Cyclops, new Vector2(x, y), Quaternion.identity);
    }

    void SpawnSkull(int x, int y)
    {
        Instantiate(Skull, new Vector2(x, y), Quaternion.identity);
    }

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SpawnCyclops(-5, 5);
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnSkull(5, 5);
        }
    }
}