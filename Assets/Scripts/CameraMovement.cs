using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Transform rightLimit;
    //public Transform leftLimit;    
    public Transform topLimit;
    public Transform bottomLimit;
    private float offsetx;
    private float offsety;
    private float startX;
    private float endX;

    private float topY;
    private float bottomY;
    private float viewportHalfWidthX;
    private float viewportHalfWidthY;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        viewportHalfWidthX = Mathf.Abs(bottomLeft.x - this.transform.position.x);
        viewportHalfWidthY = Mathf.Abs(bottomLeft.y - this.transform.position.y);
        offsetx = this.transform.position.x - player.position.x;
        offsety = this.transform.position.y - player.position.y;
        startX = this.transform.position.x;
        endX = rightLimit.transform.position.x - viewportHalfWidthX;
        topY = topLimit.transform.position.y - viewportHalfWidthY;
        bottomY = topLimit.transform.position.y + viewportHalfWidthY;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float desiredX = player.position.x + offsetx;
        float desiredY = player.position.y + offsety;
        // check if desiredX is within startX and endX
        //if (desiredX > startX && desiredX < endX && desiredY < topY && desiredY > bottomY)
        this.transform.position = new Vector3(desiredX, desiredY, this.transform.position.z);
    }
}
