using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingResetter : MonoBehaviour
{
    public Quaternion rotateinit;
    public Vector3 position;
    public float speed = 1;
    private float lerpValue = 0;
    private float lerp;
    public List<GameObject> parts;
    public List<Vector3> positions;
    public List<Quaternion> rotation;
    // Start is called before the first frame update
    void Start()
    {
       
        rotateinit = transform.rotation;
        position = transform.position;
        print(rotateinit);
        print(position);
        foreach (var item in parts)
        {
            positions.Add(item.transform.position);
            rotation.Add(item.transform.rotation);
        }
        

    }
    public void rebuild()
    {
        
        print("called");
        var i = 0;
        foreach (var item in parts)
        {
            
            print(i);
            var Temp_Pos = item.transform.position;
            item.transform.position = Vector3.Lerp(transform.position, positions[i], 1);

            var Temp_Rot = item.transform.rotation;
            item.transform.rotation = Quaternion.Lerp(transform.rotation, rotation[i], 1);
            i++;
        }
    }

   





    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            lerpValue += Time.deltaTime * speed;
            
            rebuild();
            //transform.position = Vector3.Lerp(transform.position, position, lerpValue);
            //transform.rotation = Quaternion.Lerp(transform.rotation, rotateinit, lerpValue);
        }
        else
        {
            lerpValue = 0;
        }
    }


    
}
