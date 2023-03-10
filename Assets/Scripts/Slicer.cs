using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{
    public Material materialAfterSlice;
    public LayerMask sliceMask;
    public bool isTouched;

    private void Start()
    {
        isTouched = false;
    }

    private void Update()
    {
        if (isTouched == true)
        {
            isTouched = false;

            //checks if the slicable objects have made contact with the rigidbody
            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);


            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);

                if (slicedObject != null)
                {
                    GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                    GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                    if (upperHullGameobject != null)
                    {
                        Debug.Log("Got upperhull");
                        upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                        MakeItPhysical(upperHullGameobject);
                    }

                    if (lowerHullGameobject != null)
                    {
                        Debug.Log("Got lowerhull");
                        lowerHullGameobject.transform.position = objectToBeSliced.transform.position;
                        MakeItPhysical(lowerHullGameobject);
                    }

                    Destroy(objectToBeSliced.gameObject);
                }
                else {
                    Debug.Log("SlicedObject = null :(");
                }
            }
            
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}
