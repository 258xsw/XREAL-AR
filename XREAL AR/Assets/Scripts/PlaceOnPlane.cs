using UnityEngine;

public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placedPrefab; 
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private LayerMask placedObjectLayerMask; 
    private Vector2 touchPosition;
    private Ray ray;
    private RaycastHit hit;
    private void Update()
    {
        if (!Utility.TryGetInputPosition(out touchPosition)) return;

        ray = arCamera.ScreenPointToRay(touchPosition);
        if( Physics.Raycast(ray, out hit, Mathf.Infinity, placedObjectLayerMask))
        {
            PlacedObject.SelectedObject = hit.transform.GetComponentInChildren<PlacedObject>();
            return;
        }

        PlacedObject.SelectedObject = null; 

        if (Utility.Raycast(touchPosition, out Pose hitPose))
        {
            int index = Random.Range(0, placedPrefab.Length);
            Instantiate(placedPrefab[index], hitPose.position, hitPose.rotation); 
        }
    }

}