using System;
using UnityEngine;

public class FlyingObjectFactory : MonoBehaviour
{
    public IFlyingObject GetFlyingObject(GameObject driver, FlyingObjectType type) => type switch
    {
        FlyingObjectType.Apple => driver.AddComponent<Apple>(),
        FlyingObjectType.Avocado => driver.AddComponent<Avocado>(),
        FlyingObjectType.Banana => driver.AddComponent<Banana>(),
        FlyingObjectType.Burger => driver.AddComponent<Burger>(),
        FlyingObjectType.Cherries => driver.AddComponent<Cherries>(),
        FlyingObjectType.Lemon => driver.AddComponent<Lemon>(),
        FlyingObjectType.Peach => driver.AddComponent<Peach>(),
        FlyingObjectType.Peanut => driver.AddComponent<Peanut>(),
        FlyingObjectType.Pear => driver.AddComponent<Pear>(),
        FlyingObjectType.Strawberry => driver.AddComponent<Strawberry>(),
        FlyingObjectType.Watermelon => driver.AddComponent<Watermelon>(),
        _ => throw new Exception("Not found object type exception")
    };
}
