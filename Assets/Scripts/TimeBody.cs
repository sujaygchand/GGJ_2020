using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;
    public MeshCollider mesh;

    List<PointInTime> pointsintime;
    public Rigidbody rb;

    public float recordTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshCollider>();
        pointsintime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();

        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
    }
    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
            Record();
    }
    void Rewind()
    {
        if (pointsintime.Count > 0)
        {
            PointInTime pointInTime = pointsintime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsintime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
            
        
    }
    void Record()
    {
        if (pointsintime.Count > recordTime * (1f / Time.fixedDeltaTime))
        {
            pointsintime.RemoveAt(pointsintime.Count - 1);
        }
        pointsintime.Insert(0, new PointInTime(transform.position,transform.rotation));
    }
    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
        mesh.enabled = true;
        rb.constraints = RigidbodyConstraints.None;
    }
    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        mesh.enabled = false;
    }
}
