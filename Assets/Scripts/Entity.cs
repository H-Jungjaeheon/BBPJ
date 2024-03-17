using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Entity : MonoBehaviourPunCallbacks
{
    protected Rigidbody2D rigid;
    protected Collider col;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider>();
    }
}
