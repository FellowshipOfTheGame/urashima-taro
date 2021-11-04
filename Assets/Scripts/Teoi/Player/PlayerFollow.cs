using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 initialCamPos;
    // Start is called before the first frame update
    void Start()
    {
        initialCamPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        pos += initialCamPos;
        pos.z = initialCamPos.z;
        this.transform.position = pos;
    }
}
