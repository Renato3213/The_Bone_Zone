using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Points;
    [SerializeField] Waypoints waypoints;

    [SerializeField] float speed;

    public int damage = 1;

    Transform target;
    int pointIndex = 0;

    void Start()
    {
        waypoints = Points.GetComponent<Waypoints>();
        target = waypoints.points[0];

    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextPoint();
        }
    }

    void GetNextPoint()
    {
        if(pointIndex >= waypoints.points.Length - 1)
        {
            GameManager.instance.AtualizaVidas(damage);
            Destroy(gameObject);
            return;
        }

        pointIndex++;

        target = waypoints.points[pointIndex];
    }
}
