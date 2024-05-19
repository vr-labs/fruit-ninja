﻿using UnityEngine;

public class Lemon : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Lemon;
    
    public override Vector3 GetSize()
    {
        return new Vector3(15f, 15f, 15f);
    }
}
