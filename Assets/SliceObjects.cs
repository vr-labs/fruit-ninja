using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObjects : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public LayerMask sliceableLayer;
    public VelocityEstimator velocityEstimator;

    public Material crossSectionMaterial;
    public float cutForce = 2000f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit,
            this.sliceableLayer);

        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, this.crossSectionMaterial);
            SetupSliceComponent(upperHull);
            GameObject lowerHull = hull.CreateLowerHull(target, this.crossSectionMaterial);
            SetupSliceComponent(lowerHull);
            
            Destroy(target);
        }
    }

    public void SetupSliceComponent(GameObject slicedObject)
    {
        Rigidbody rigidBody = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        
        rigidBody.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
    }
}
