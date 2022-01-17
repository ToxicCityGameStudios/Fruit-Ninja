using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
