using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMatChange : MonoBehaviour {

[SerializeField] Material material;

[HideInInspector] [SerializeField] new Camera camera;
[HideInInspector] [SerializeField] Vector3 screenCenter;


void Reset () {
    camera = GetComponent<Camera>();
    screenCenter = new Vector3(.5F, .5F, 0);
}


class ChangedObject {
    public Renderer renderer;
    public Material originalMaterial;


 public ChangedObject (Renderer renderer, Material material) {
     this.renderer = renderer;
     originalMaterial = renderer.sharedMaterial;
     renderer.material = material;
    }
}


ChangedObject changedObject;
RaycastHit raycastHit;
void Update () {
    camera = Camera.main;
    Ray ray = camera.ViewportPointToRay(screenCenter);
    if (Physics.Raycast(ray, out raycastHit)) {
        Renderer hitRenderer = raycastHit.transform.GetComponent<Renderer>();
        if (hitRenderer) {
            if (changedObject != null)
                if (changedObject.renderer == hitRenderer) return;
                else changedObject.renderer.material = changedObject.originalMaterial;
            changedObject = new ChangedObject(hitRenderer, material);
        }
    } 
    else if (changedObject != null) {
        changedObject.renderer.material = changedObject.originalMaterial;
        changedObject = null;
        }
    }
}