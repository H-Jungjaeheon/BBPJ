using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Entity : MonoBehaviour
{
    protected Rigidbody2D rigid;
    protected Collider col;
    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider>();
    }
}
