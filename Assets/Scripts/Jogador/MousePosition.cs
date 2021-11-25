using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Rigidbody2D rb;
    private Vector2 mousePos;

    public float angulo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();
    }

    public void Rotation()
    {
        Vector2 inputVec = InputManager.GetInstance().GetRotation();

        if (InputManager.GetInstance().GetDevice() == "Mouse")
        {
            mousePos = cam.ScreenToWorldPoint(inputVec);
            inputVec = mousePos - rb.position;
        }

        angulo = Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg - 90f;
    }
}
