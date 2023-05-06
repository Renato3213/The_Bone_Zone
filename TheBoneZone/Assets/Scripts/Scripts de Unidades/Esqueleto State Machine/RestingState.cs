using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingState : SkeletonState
{
    Bares pub;
    public override void DoState(Skeleton skeleton)
    {
        if (skeleton.walking == true &&
            Vector3.Distance(skeleton.transform.position, skeleton.pubTarget.transform.position) >= 2.5f)
        {
            skeleton.stateInitialized = false;

            return;
        }


        if (!skeleton.stateInitialized)
        {
            skeleton.stateInitialized = true;
            skeleton.walking = false;
            skeleton.doingTask = true;
            pub = skeleton.pubTarget;

            skeleton.agent.isStopped = true;
            skeleton.agent.enabled = false;
            skeleton.transform.position = GameManager.instance.deposit.transform.position;
            //pub.myInterface.Atualiza();
        }
        Rest(skeleton);

    }

    void Rest(Skeleton skeleton)
    {
        skeleton.energy += Time.deltaTime / skeleton.myStats.workTime > 1 ? 1 : Time.deltaTime / skeleton.myStats.workTime;

        if(skeleton.energy == 1)
        {
            pub.LiberaEsqueleto(skeleton);
        }
    }
}
