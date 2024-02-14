using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Ball : Entity
{
    public float bounceCount = 3;
    protected override void Start()
    {
        base.Start();
        RandomVelocity();
    }
    private void Update()
    {
        if (rigid.angularVelocity <= bounceCount * 2)
        {
            rigid.AddForce(rigid.velocity.normalized, ForceMode2D.Force);
        }
    }
    public void RandomVelocity()
    {
        var vec = Random.insideUnitCircle * 10;
        rigid.AddForce(vec, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        bounceCount++;
    }
    public void StrikeFunc(Vector3 dir)
    {
        bounceCount++;
        rigid.velocity = bounceCount * dir;
        rigid.AddForce(dir, ForceMode2D.Force);
    }
}
