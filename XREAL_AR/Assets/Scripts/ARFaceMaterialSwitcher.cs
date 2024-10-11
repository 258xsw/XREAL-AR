using UnityEngine;
using UnityEngine.XR.ARFoundation; 

public class ARFaceMaterialSwitcher : MonoBehaviour
{
    [SerializeField]
    private Material[] materials; 
    private ARFaceManager faceManager; 
    private int index = 0; 

    private void Start()
    {
        faceManager = GetComponent<ARFaceManager>(); 
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            index = (index + 1) % materials.Length; 

            foreach (ARFace face in faceManager.trackables)
            {
                face.GetComponent<MeshRenderer>().material = materials[index];
            }
        }
    }
}