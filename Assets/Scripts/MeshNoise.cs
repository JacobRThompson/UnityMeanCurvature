
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshNoise : MonoBehaviour
{
    public Mesh mesh;
    public bool useNoise;
    [Range(0.1f, 10)] public float amplitude;
    [Range(0.1f, 10)] public float period;

    [Range(1,5)] public int noiseOctaves;

    private float t;
    private Vector3[] vertices;
   
   //Note that this is called after OnEnable() within CombineMesh.cs 
    private void Start() {
        //reset the size of our object
        transform.localScale=new Vector3(1,1,1);

        // get the mesh attached to this gameObject
        mesh =GetComponent<MeshFilter>().sharedMesh;
        vertices =  (Vector3[]) mesh.vertices;
    }
    
    //Called every frame
    private void Update() {
        // increment time
        t+=Time.deltaTime/period;
        if (useNoise){
            ApplyNoise();
            mesh.RecalculateNormals();
            }
    }

    public void ApplyNoise(){

        var i = 0;
        var vertCopy = (Vector3[]) vertices.Clone();
        // we iterate over a copy of our vert array since we are going to be modifying the values of
        // it
        foreach (Vector3 vert in vertCopy){

            var temp=Vector3.zero;
            for (int j = 0; j < noiseOctaves; j++)
            {

                temp+= new Vector3(0,
                    1/(j+1)*PerlinNoise3D(vert.x*Mathf.Exp(j), Time.time/period*Mathf.Exp(j), vert.z*Mathf.Exp(j)
                    )
                );
            }


            vertices[i]=new Vector3(vert.x,PerlinNoise3D(vert.x, Time.time/period ,vert.z)*amplitude, vert.z);
            i++;
        }
        mesh.vertices = vertices;
        
    }

    /// <summary>
    /// Creates pseudo-random noise using 3 coordinate value. Credit to user danrayson at https://answers.unity.com/questions/938178/3d-perlin-noise.html
    /// <returns> float between 0.0 and 1.0 (approx) </returns>
    public float PerlinNoise3D(float x, float y, float z){
        y += 1;
        z += 2;
        float xy = _perlin3DFixed(x, y);
        float xz = _perlin3DFixed(x, z);
        float yz = _perlin3DFixed(y, z);
        float yx = _perlin3DFixed(y, x);
        float zx = _perlin3DFixed(z, x);
        float zy = _perlin3DFixed(z, y);
        return xy * xz * yz * yx * zx * zy;
    }
    float _perlin3DFixed(float a, float b){
        return Mathf.Sin(Mathf.PI * Mathf.PerlinNoise(a, b));
    }

}

