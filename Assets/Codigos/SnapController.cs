using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggabledObjects;
    public float snapRange = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Draggable draggable in draggabledObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
        
    } 

    void Update()
    {
        
    }

    private void OnDragEnded(Draggable draggable)
    {
        float closesDistance = -1;
        Transform closesSnapPoint = null;
        bool allSnapped = false;

        foreach (Transform snapPoint in snapPoints){
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if(closesSnapPoint == null || currentDistance < closesDistance){
                closesSnapPoint = snapPoint;
                closesDistance = currentDistance;
            }
        }

        if(closesSnapPoint != null && closesDistance <= snapRange){
            draggable.transform.localPosition = closesSnapPoint.localPosition;
            draggable.inPosition = true;
            draggable.GetComponent<Collider>().enabled = false;
            // check if all draggable objects are snapped to snap points
            allSnapped = true; 
            foreach(Draggable obj in draggabledObjects){
                /*if(obj.transform.localPosition != closesSnapPoint.localPosition){
                    allSnapped = true;
                }*/
                if (obj.inPosition == false) {
                    allSnapped = false; 
                }
            }
            // if all draggable objects are snapped, print "done" to console
            if(allSnapped)
            {
                print("Done");
                SceneManager.LoadScene(3);

            }
        }
    }

    public void Game()
    {
        
    }
}
