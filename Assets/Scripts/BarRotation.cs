using UnityEngine;
using System.Collections;

public class BarRotation : MonoBehaviour {

    public float speed = 0.5f;

    public bool isHit;

    public float angle = 0;

    public bool leftSide;

    public bool isTouchLeft;
    public bool isTouchRight;

	// Use this for initialization
	void Start () {

        


    }
	
	// Update is called once per frame
	void Update () {

        TouchEvent();

        if(leftSide)
        {

            if (Input.GetKey(KeyCode.X) || isTouchLeft)
            {
                isHit = true;
            }
            if (Input.GetKeyUp(KeyCode.X) || !isTouchLeft)
            {
                isHit = false;
            }

            if (isHit)
            {
                if (angle < 0.6)
                {
                    angle += 0.1f;
                    this.gameObject.transform.rotation = Quaternion.EulerAngles(0, 0, angle);
                }
            }
            else
            {
                if (angle > 0.0)
                {
                    angle -= 0.05f;
                    this.gameObject.transform.rotation = Quaternion.EulerAngles(0, 0, angle);
                }
            }
        }
        else
        {

            if (Input.GetKey(KeyCode.C) || isTouchRight)
            {
                isHit = true;
            }
            if (Input.GetKeyUp(KeyCode.C) || !isTouchRight)
            {
                isHit = false;
            }

            if (isHit)
            {
                if (angle > -3.7f)
                {
                    angle -= 0.1f;
                    this.gameObject.transform.rotation = Quaternion.EulerAngles(0, 0, angle);
                }
            }
            else
            {
                if (angle < -3.1f)
                {
                    angle += 0.05f;
                    this.gameObject.transform.rotation = Quaternion.EulerAngles(0, 0, angle);
                }
            }
        }
        
	}

    void TouchEvent()
    {
        if (Input.touchCount > 0)
        {
            Vector2 pos = Input.GetTouch(0).position;
            Vector3 theTouch = new Vector3(pos.x, pos.y, 0.0f);

            Ray ray = Camera.main.ScreenPointToRay(theTouch);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("LeftHitBar"))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        isTouchLeft = true;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        isTouchLeft = false;
                    }
                }
                else if (hit.collider.CompareTag("RightHitBar"))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        isTouchRight = true;
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        isTouchRight = false;
                    }
                }
            }
        }
    }
}
