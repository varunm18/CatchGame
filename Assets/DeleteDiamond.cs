using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDiamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -50)
        {
            GameObject particles = transform.GetChild(0).gameObject;
            particles.transform.parent = null;

            ParticleSystem particleSys = particles.GetComponent<ParticleSystem>();
            particleSys.Stop();

            Destroy(this.gameObject);
            Destroy(particles, 5.5f);
        }
    }
}
