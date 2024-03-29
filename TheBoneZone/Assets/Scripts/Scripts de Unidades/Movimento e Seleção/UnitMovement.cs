using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Camera cam;
    NavMeshAgent myAgent;
    public LayerMask ground;
    public static List<NavMeshAgent> meshAgents = new List<NavMeshAgent>();
    [SerializeField] GameObject clickMesh;
    Skeleton thisSkeleton;

    void Start()
    {
        cam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
        meshAgents.Add(myAgent);
        thisSkeleton= GetComponent<Skeleton>();
    }

    void Update()
    {
        if (!UnitSelection.Instance.unitsSelected.Contains(thisSkeleton)) return;
        if (!meshAgents.Contains(myAgent)) 
        {
            meshAgents.Add(myAgent);
        }

        //else
        //{
        //    meshAgents.Add(myAgent);
        //}

        if (GameManager.instance.IsMouseOverObject()) return;

        if (Input.GetMouseButtonDown(1) && meshAgents.Contains(myAgent))
        {

            if (meshAgents.IndexOf(myAgent) == 0)
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    CancelTask();
                    Instantiate(clickMesh, hit.point, Quaternion.identity);
                    myAgent.SetDestination(hit.point);
                }

                float angle = 60;
                int countOnCircle = (int)(360 / angle);
                int count = meshAgents.Count;
                float step = 0.75f;
                int i = 1;
                float randomizeAngle = Random.Range(0, angle);
                while (count > 1)
                {
                    var vec = Vector3.forward;
                    vec = Quaternion.Euler(0, angle * (countOnCircle - 1) + randomizeAngle, 0) * vec;
                    meshAgents[i].SetDestination(myAgent.destination + vec * (myAgent.radius + meshAgents[i].radius + 0.75f) * step);
                    countOnCircle--;
                    count--;
                    i++;
                    if (countOnCircle == 0)
                    {
                        if (step != 3 && step != 4 && step < 6 || step == 10) { angle /= 2f; }

                        countOnCircle = (int)(360 / angle);
                        step += 0.75f;
                        randomizeAngle = Random.Range(0, angle);
                    }
                }

            }
        }

        
    }

    void CancelTask()
    {
        foreach(Skeleton skeleton in UnitSelection.Instance.unitsSelected)
        {
            skeleton.isBuilding= false;
            skeleton.isDelivering= false;
            skeleton.isFarming= false;
            skeleton.isGrinding= false;
            skeleton.isResting = false;
            skeleton.reseted = true;
            //skeleton.ResetSkeleton();
        }
    }

    void OnDisable()
    {
        meshAgents.Clear();
    }
}