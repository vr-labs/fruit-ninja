using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonBase : MonoBehaviour
{
    public abstract bool IsStop { get; }

    public GameObject ObjectPrefab
    {
        get => prefab;
        set => prefab = value;
    }

    [SerializeField]
    public GameObject prefab;

    public Vector3 GetSize = new(20f, 20f, 20f);

    public virtual void OnHit()
    {
        if (IsStop)
        {
            GameManager.Instance.PauseGame();
        }
        else
        {
            GameManager.Instance.StartGame();
        }
    }
}
