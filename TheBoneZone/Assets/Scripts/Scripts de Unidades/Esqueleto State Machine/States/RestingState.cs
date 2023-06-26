using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingState : ISkeletonState
{

    Skeleton skeleton;
    Bares pub;


    Vector3 closestPubPosition;
    Bares closestPub;
    public void OnEnter(Skeleton skeleton)
    {
        this.skeleton = skeleton;
        //ControlaListas.instance.skeletonsGrinding.Add(skeleton);
        skeleton.transform.position = GameManager.instance.deposit.transform.position;
        skeleton.agent.enabled = false;

        if(skeleton.pubID == -1)
        {
            if (skeleton.grinderTarget != null)
            {
                pub = skeleton.pubTarget;
                skeleton.pubID = skeleton.pubTarget.myId;
                pub.descansandoAqui.Add(skeleton);
                pub.AtualizaInterface();
            }

        }
        else
        {
            pub = ControlaListas.instance.pubsList.Find((pub) => pub.myId == skeleton.pubID);
            pub.descansandoAqui.Add(skeleton);
        }
        
        //if (skeleton.grinderTarget == null)
        //{
        //    pub = FindClosestPub(skeleton);
        //}



        //if (pub != null)
        //    pub.workingHere++;
    }

    public void OnExit()
    {
        pub.descansandoAqui.Remove(skeleton);
        skeleton.pubID = -1;

        //pub.workingHere--;
    }

    Bares FindClosestPub(Skeleton skeleton)
    {

        closestPubPosition = Vector3.positiveInfinity;
        Vector3 grinderPosition;
        foreach (Bares pub in ControlaListas.instance.pubsList)
        {
            grinderPosition = pub.transform.position;
            if (Vector3.Distance(skeleton.transform.position, grinderPosition) < Vector3.Distance(skeleton.transform.position, closestPubPosition))
            {
                closestPub = pub;
                closestPubPosition = grinderPosition;
            }
        }

        return closestPub;
    }


    public void OnUpdate()
    {
        Rest(skeleton);
    }
    
    void Rest(Skeleton skeleton)
    {
        skeleton.energy += Time.deltaTime / skeleton.myStats.workTime > 1 ? 1 : Time.deltaTime / skeleton.myStats.workTime;

        if (skeleton.energy == 1)
        {
            pub.LiberaEsqueleto(skeleton);
        }
    }

   
}
