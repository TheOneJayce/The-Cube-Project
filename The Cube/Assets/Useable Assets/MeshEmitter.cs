using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshEmitter : MonoBehaviour
{
    public SkinnedMeshRenderer skin;
    Mesh baked;
    ParticleSystem particle;
    ParticleSystemRenderer render;
    public bool emit;
    public float coolDown = 0.5f;
    float interval = 0;

    // Use this for initialization
    void Start()
    {
        if (!skin)
            this.enabled = false;
        particle = GetComponent<ParticleSystem>();
        render = GetComponent<ParticleSystemRenderer>();
    }
// Update is called once per frame
void Update()
    {
        if (emit)
        {
            interval -= Time.deltaTime;
            if (interval < 0)
            {
                GameObject newEmitter = Instantiate(gameObject, transform.position, transform.rotation) as GameObject;
                newEmitter.GetComponent<MeshEmitter>().EmitMesh();
                interval = coolDown;
            }
        }
        else
        {
            interval = coolDown;
        }
    }

    public void EmitMesh()
    {
        emit = false;
        baked = new Mesh();
        skin.BakeMesh(baked);
        particle = GetComponent<ParticleSystem>();
        render = GetComponent<ParticleSystemRenderer>();
        render.mesh = baked;
        particle.Play();
        Destroy(gameObject, particle.duration);
    }
}
