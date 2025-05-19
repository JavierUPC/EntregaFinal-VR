using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cans : MonoBehaviour
{
    private Rigidbody rb;
    public Shoot shooting;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!rb.isKinematic)
        {
            return;
        }

        rb.isKinematic = false;
        shooting.contarLatas();
    }
}
