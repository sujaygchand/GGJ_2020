using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDestroyer : MonoBehaviour
{

    public float ParticlesDuration;
    // Start is called before the first frame update
    void Start()
    {
        if(ParticlesDuration==0)
        {
            ParticlesDuration = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ParticlesDuration = ParticlesDuration - Time.deltaTime;

        if(ParticlesDuration<=0)
        {
            Destroy(gameObject);
        }
    }
}
