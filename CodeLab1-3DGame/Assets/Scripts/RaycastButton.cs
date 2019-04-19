using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastButton : MonoBehaviour
{
    public GameObject[] Heads;
    
        
    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y);
        
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
                // instead of destroying collider, change to a random gameobject prefab from a list?
                // if tag = eye, then instantiate another eye prefab and so on for all other facial features

                if (gameObject.CompareTag("Head"))
                {
                    // destroy current gameobject
                    Destroy(myRaycastHitInfo.collider.gameObject);
                    
                    // replace gameobject to random from list
                    int i = Random.Range(0, Heads.Length);
                    Instantiate(Heads[i], position, Quaternion.identity);
                }
            }
        }
    }
}
