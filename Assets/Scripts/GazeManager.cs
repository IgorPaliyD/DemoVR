using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera viewCamera;
    public GameObject lastGazedUpon;
    private GameObject currentGaze;
    
    string lastName="";
      
    void FixedUpdate()
    {
        CheckGaze();
    }
    private void CheckGaze()
    {
        
        Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        
        
        if (Physics.Raycast(gazeRay, out hit, Mathf.Infinity))
        {   
            if(lastName!="" && lastName!=hit.transform.name){
                lastGazedUpon.SendMessage("NotGazingUpon",SendMessageOptions.DontRequireReceiver);
                lastName = hit.transform.name;
            }
            else{
                if(hit.collider.gameObject.CompareTag("Look")){
                    lastName = hit.transform.name;
                    hit.transform.SendMessage("GazingUpon", SendMessageOptions.DontRequireReceiver);
                    lastGazedUpon =  hit.transform.gameObject;
                }
            }
            
            
        }
        else if(lastGazedUpon!=null){
          
            lastGazedUpon.SendMessage("NotGazingUpon", SendMessageOptions.DontRequireReceiver);
        }
        
    }

}
