using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivesController : MonoBehaviour
{
    public UnityEvent OnLiveChange;
    public int Lives { get; private set; }

    public void ReduceLives()
    {
        Lives--;
        OnLiveChange.Invoke();
    }

    public int GetLives()
    {
        return Lives;
    }

    public void SetLives(int amount)
    {
        Lives = amount;
        OnLiveChange.Invoke();
    }
}
