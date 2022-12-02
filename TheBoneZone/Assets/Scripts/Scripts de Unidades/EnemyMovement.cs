using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Points;
    [SerializeField] Waypoints waypoints;

    [SerializeField] float speed;

    public float damage = 1;

    Transform target;
    int pointIndex = 0;

    void Start()
    {
        waypoints = Points.GetComponent<Waypoints>();
        target = waypoints.points[0];
    }

    private void Awake()
    {
        damage = 1 + (9 * (GameManager.instance.Infamia / 100));
        speed = 5 + (4 * (GameManager.instance.Infamia / 100));
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
