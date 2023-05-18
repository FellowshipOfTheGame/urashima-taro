using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    /*
    public GameObject shadowPrefab;
    public Transform shadowPosition;

    //public LightSource[] lightSources;
    public List<Transform> shadows;
    public List<Transform> lights;

    public float minScale;
    public float maxScale;
    public float minDistance;
    public float maxDistance;

    private float shadowScaleY;

    void Start()
    {
        // Stores all light sources of the scene (Objects with the script called 'LightSource' on it)
        lightSources = FindObjectsOfType(typeof(LightSource)) as LightSource[];

        // For each light source, create a shadow bellow this object
        // Also stores the position of all light sources and the created shadows 
        for (int i = 0; i < lightSources.Length; i++)
        {
            lights.Add(lightSources[i].transform);
            GameObject tempShadow = Instantiate(shadowPrefab, shadowPosition.position, shadowPosition.localRotation, this.transform);
            shadows.Add(tempShadow.transform);
        }
    }

    // Updates after the Update method
    void LateUpdate()
    {
        // For each light source, updates the direction of the shadow and its Y scale
        for (int i = 0; i < lightSources.Length; i++)
        {
            Vector3 direction = lights[i].transform.position - this.transform.position;
            shadows[i].up = direction;

            float distance = Vector3.Distance(transform.position, lights[i].transform.position);

            shadowScaleY = distance * maxScale / maxDistance;
            //Debug.Log(shadowScaleY);
            if (shadowScaleY < minScale)
            {
                shadowScaleY = minScale;
            }
            else if (shadowScaleY > maxScale || distance >= maxDistance)
            {
                shadowScaleY = maxScale;
            }

            shadows[i].localScale = new Vector3(shadows[i].localScale.x, shadowScaleY, shadows[i].localScale.z);
        }
    }
    */
}
