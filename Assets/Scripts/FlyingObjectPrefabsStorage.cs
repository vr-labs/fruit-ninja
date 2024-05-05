using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FlyingObjectPrefabsStorage : MonoBehaviour
{
    [SerializeField]
    public GameObject applePrefab;
    
    [SerializeField]
    public GameObject avocadoPrefab;
    
    [SerializeField]
    public GameObject bananaPrefab;
    
    [SerializeField]
    public GameObject burgerPrefab;
        
    [SerializeField]
    public GameObject cherriesPrefab;
        
    [SerializeField]
    public GameObject lemonPrefab;
        
    [SerializeField]
    public GameObject peachPrefab;
        
    [SerializeField]
    public GameObject peanutPrefab;
        
    [SerializeField]
    public GameObject pearPrefab;
        
    [SerializeField]
    public GameObject strawberryPrefab;
        
    [SerializeField]
    public GameObject watermelonPrefab;

    public GameObject GetPrefabByType(FlyingObjectType type) => type switch
    {
        FlyingObjectType.Apple => applePrefab,
        FlyingObjectType.Avocado => avocadoPrefab,
        FlyingObjectType.Banana => bananaPrefab,
        FlyingObjectType.Burger => burgerPrefab,
        FlyingObjectType.Cherries => cherriesPrefab,
        FlyingObjectType.Lemon => lemonPrefab,
        FlyingObjectType.Peach => peachPrefab,
        FlyingObjectType.Peanut => peanutPrefab,
        FlyingObjectType.Pear => pearPrefab,
        FlyingObjectType.Strawberry => strawberryPrefab,
        FlyingObjectType.Watermelon => watermelonPrefab,
        _ => throw new Exception("Object type not found")
    };
}
