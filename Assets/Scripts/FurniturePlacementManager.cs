using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Networking;
using Lean.Touch;
public class FurniturePlacementManager : MonoBehaviour
{
    public GameObject furniture;
    public XROrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    //public TouchControl controls;
    GameObject _object;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Start()
    {
        furniture = StateNameController.Product;
        furniture.AddComponent<LeanTwistRotateAxis>();
        furniture.AddComponent<LeanDragTranslate>();
    }

    private void Update()
    {
        
     if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase==TouchPhase.Began)
            {
                bool collision = raycastManager.Raycast(Input.GetTouch(0).position, raycastHits, TrackableType.PlaneWithinPolygon);
                if (_object==null&&collision && !isPressed())
                {
                    _object = Instantiate(furniture);
                    
                    _object.transform.position = raycastHits[0].pose.position;
                    _object.transform.rotation = raycastHits[0].pose.rotation;
                }
                foreach(var planes in planeManager.trackables)
                {
                    planes.gameObject.SetActive(false); 
                }

            }
        }   
    }

    public bool isPressed()
    {
        if (EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void OnDestroy()
    {
        if( _object != null ) { Destroy(_object); }
    }
    public void SwitchFirniture(GameObject Newfurniture)
    {
        furniture = Newfurniture;
    }

}
