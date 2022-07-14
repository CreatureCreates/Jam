using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollisions : MonoBehaviour
{
    // Use this for initialization
    void Start () {
 
        // Iterate through all child objects of our Geometry object
        foreach (Transform childObject in transform)
        {
            
            // get the mesh attached to each child object
            try
            {
                Mesh mesh = childObject.gameObject.GetComponent<MeshFilter>().mesh;

                // If we've found a mesh we can use it to add a collider
                if (mesh != false)
                {                      
                    // Add a new MeshCollider to the child object
                    MeshCollider meshCollider = childObject.gameObject.AddComponent<MeshCollider>();
                    meshCollider.convex = true;
                    // Finaly we set the Mesh in the MeshCollider
                    meshCollider.sharedMesh = mesh;
                }
            }
            catch (MissingComponentException)
            {
                // if no mesh collider was found, do nothing.
            }
            
        }
    }
}