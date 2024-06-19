using UnityEngine;

public class Burger : FlyingObjectBase
{
    public override FlyingObjectType Type => FlyingObjectType.Burger;
    public override float AppearingChance => 0.29f;


    public override void OnHit()
    {
        GameManager.Instance.AddScore(-3);
    }
    
    public override Vector3 GetSize()
    {
        return Vector3.one * 0.25f;
    }
}
