using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    private float re;
    private bool built = false;

    // Start is called before the first frame update
    void Start()
    {

        rotateinit = transform.rotation;
        position = transform.position;
        //print(rotateinit);
        //print(position);
        foreach (var item in parts)
        {
            positions.Add(item.transform.position);
            rotation.Add(item.transform.rotation);
        }


    }
    public void Rebuild()
    {


    }

    public void BuiltState()
    {
        if (built == true)
        {
            //pause all of the rigid bodies

        }
        else
        {

        }
    }


    public float lerpCounter(float i)
    {
        float re = 0.0f;
        float rate = (1.0f / 5) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            re = i;

        }
        return re;
    }



    // Update is called once per frame
    void Update()
    {

        bool built = false;


        if (Input.GetKey(KeyCode.Space))
            built = !built;

        if (built)
        {


            //print(built);
            var i = 0;
            foreach (var item in parts)
            {
                print(i);
                var Temp_Pos = item.transform.position;
                //Stuff
                item.transform.position = Vector3.Lerp(transform.position, positions[i], 1);
                
                var Temp_Rot = item.transform.rotation;
                item.transform.rotation = Quaternion.Lerp(transform.rotation, rotation[i], 1);
                i++;
            }
        }
        //light.enabled = true;
        else if (!built)
        {
            //print(built);
        }


    }



}
