using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragobject : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;
    public Transform SpawnPointContainer;      // Assign parent gameobject of spawn points.
    private Transform[] spawnPoints;
    //private void Start()
    //{
        // Initialize spawnPoints array.
      //  spawnPoints = new Transform[.childCount];
        // Populate array with child transforms.
        //for (int i = 0; i < spawnPointContainer.childCount; i++)
        //{
          //  spawnPoints[i] = spawnPointContainer.GetChild(i);
        //}
    //}
    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }
    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()

    {

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }

    // Start is called before the first frame update

}
