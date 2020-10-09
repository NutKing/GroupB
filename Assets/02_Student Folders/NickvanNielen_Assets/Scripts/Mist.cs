using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour
{
    public ParticleSystem Ps;

    private ParticleSystem.MainModule main;
    // Start is called before the first frame update
    void Start()
    {
        main = Ps.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseMist() {
        main.startLifetime = 10f;
    }
}
