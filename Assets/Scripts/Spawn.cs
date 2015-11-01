using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public Transform tsumtsum;
    public int SpawnNum;
    public bool isTsumTusm;
    public float delayTime;
    public float preatingTime;
    public float clusterDelayTime;
    public float clusterRepeatingTime;

    private GameObject instantiateObj;

    public int tsumtsumsLimit;
    public int tsumtsumCount;

    private bool isTouch;

	// Use this for initialization
	void Start () {
        if(isTsumTusm)
        {
            for (int i = 0; i < SpawnNum; i++)
            {
                Instantiate(tsumtsum, this.transform.position, Quaternion.identity);
            }

            InvokeRepeating("LaunchTsumTusmsCluster", clusterDelayTime, clusterRepeatingTime);
            InvokeRepeating("LaunchTsumTusms", delayTime, preatingTime);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(!isTsumTusm)
        {
            TouchEvent();

            if (Input.GetKeyDown(KeyCode.L) || isTouch)
            {
                Instantiate(tsumtsum, this.transform.position, Quaternion.identity);
            }
        }

        tsumtsumCount = GameObject.FindGameObjectsWithTag("TsumTsum").Length;

	}

    void LaunchTsumTusms()
    {
        if (tsumtsumCount < tsumtsumsLimit)
        {
            Instantiate(tsumtsum, this.transform.position, Quaternion.identity);
        }
    }

    void LaunchTsumTusmsCluster()
    {
        if (tsumtsumCount < tsumtsumsLimit)
        {
            for (int i = 0; i < 13; i++)
            {
                Instantiate(tsumtsum, this.transform.position, Quaternion.identity);
            }
        }
    }

   void TouchEvent()
    {
       if(Input.touchCount > 0)
       {
           Vector2 pos = Input.GetTouch(0).position;
           Vector3 theTouch = new Vector3(pos.x, pos.y, 0.0f);

           Ray ray = Camera.main.ScreenPointToRay(theTouch);
           RaycastHit hit = new RaycastHit();
           if(Physics.Raycast(ray, out hit, Mathf.Infinity))
           {
               if (hit.collider.CompareTag("Tresh"))
               {
                   if (Input.GetTouch(0).phase == TouchPhase.Began)
                   {
                       isTouch = true;
                   }
                   else
                   {
                       isTouch = false;
                   }
               }
           }
       }
    }
}
