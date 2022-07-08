using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceVirtualObject : MonoBehaviour
{
    public GameObject gameObjectPrefab;

    private GameObject _gameObjectSpawned;
    private ARRaycastManager aRRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }
    
    bool TryToGetTouch(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryToGetTouch(out Vector2 touchPosition))
        {
            return;
        }

        if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (_gameObjectSpawned == null)
            {
                _gameObjectSpawned = Instantiate(gameObjectPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                _gameObjectSpawned.transform.position = hitPose.position;
            }
        }
    }
}
