using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    public float speed = 30f;
    public float damage;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    private void Awake()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            //referencia o inimigo para causar dano.
            Enemy enemy = target.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);


            Destroy(this.gameObject);
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
    }
    
}
