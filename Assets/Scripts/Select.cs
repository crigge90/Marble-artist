using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {


    public GameObject selectedObject = null;
	
	void Update ()
    {
        Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.magenta);

        if (Physics.Raycast(ray, out hit, 10))
        {
            GameObject hitObject = hit.collider.gameObject;
            SelectedObject(hitObject);
            Debug.Log(hit.collider);
            DestroyObject(hitObject);
        }
        else
        {
            ClearSelection();
        }
    }

    void SelectedObject (GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)

                return;
            ClearSelection();
        }
        selectedObject = obj;
        Renderer r = selectedObject.GetComponent<Renderer>();
        Material m = r.material;
        m.color = Color.red;
        r.material = m;
    }

    void ClearSelection ()
    {
        if (selectedObject == null)
        {
            return;
        }

        Renderer r = selectedObject.GetComponent<Renderer>();
        Material m = r.material;
        m.color = Color.white;
        r.material = m;

        selectedObject = null;
    }

    void DestroyObject (GameObject targetObj)
    {
        if (Input.GetMouseButtonUp(0) == true && targetObj.tag == "Block")
        {
            Destroy(targetObj);
        }
    }
}
