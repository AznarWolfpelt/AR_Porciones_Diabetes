using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public GameObject objectPrefab;

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;

    private GameObject spawnedObject;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        // Si ya colocó el objeto, no seguir detectando
        if (spawnedObject != null)
            return;

        // Verificar toque
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        // Raycast a planos
        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            // Instanciar objeto
            spawnedObject = Instantiate(objectPrefab, hitPose.position, Quaternion.identity);
            FoodManager manager = FindFirstObjectByType<FoodManager>();

            manager.foodAnchor = spawnedObject.transform.Find("FoodAnchor");
            Debug.Log("Objeto colocado");

            // Ocultar todos los planos
            foreach (ARPlane plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            // Desactivar detección futura
            planeManager.enabled = false;
        }
    }
}