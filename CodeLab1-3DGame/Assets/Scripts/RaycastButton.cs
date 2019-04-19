using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastButton : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // generate a "ray" variable
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //visualize the raycast in the debug scene view
        Debug.DrawRay(myRay.origin, myRay.direction * 100, Color.yellow);
        
        // initialize a "RaycastHit" variable
        RaycastHit myRaycastHitInfo = new RaycastHit();
        
        // shoot raycast
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(myRay, out myRaycastHitInfo, 1000f))
            {
                Destroy(myRaycastHitInfo.collider.gameObject);
                
                // instead of destroying collider, change to a random sprite prefab from an array?
            }
        }
    }
}
