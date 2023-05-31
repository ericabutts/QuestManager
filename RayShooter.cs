using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private bool IsFiring;
    public Camera cam;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        CheckIfMouseClicked();

    }
    void CreateRaycastFromPlayerToClickedGameObject() {
        Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2,0);
        Ray ray = cam.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<IInteractable>() != null) {
                hitObject.GetComponent<IInteractable>().Interact();
            }
        }

    }
    void CheckIfMouseClicked() {
        if (Input.GetMouseButtonDown(0)) {
            IsFiring = true;
            CreateRaycastFromPlayerToClickedGameObject();
        }
        if(Input.GetMouseButtonUp(0)) { 
            IsFiring = false;  
        }
    }
    void OnGUI() {
    int size = 12;
    float posX = cam.pixelWidth/2 - size/4;
    float posY = cam.pixelHeight/2 - size/2;
    GUI.Label(new Rect(posX,posY,size,size), "*");

    }
}
