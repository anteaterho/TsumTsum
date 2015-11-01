using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {

    private Vector3 screenPos;
    private Vector3 offset;

	void OnMouseDown()
    {
        screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);

        Vector3 curpos = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curpos;
    }
}
