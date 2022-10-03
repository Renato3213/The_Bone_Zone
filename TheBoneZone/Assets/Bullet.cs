using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    public float speed = 10f;
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
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            GameManager.instance.AtualizaMoedas(enemy.moedas);
            Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
    }
    
}
