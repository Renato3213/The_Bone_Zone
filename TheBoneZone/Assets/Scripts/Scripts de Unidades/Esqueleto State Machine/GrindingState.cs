using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrindingState : SkeletonState
{
    bool initiated = false;
    Fazendas grinder;
    public override void DoState(Skeleton skeleton)
    {
        if (skeleton.walking == true &&
            Vector3.Distance(skeleton.transform.position, skeleton.grinderTarget.transform.position) >= 2.5f)
        {
            initiated = false;

            return;
        }

        Debug.Log("aaa");

        if (!initiated)
        {
            initiated = true;
            skeleton.walking = false;
            skeleton.doingTask = true;
            grinder = skeleton.grinderTarget;
            //skeleton.StartCoroutine(Grind(skeleton));

            skeleton.agent.isStopped = true;
            skeleton.agent.enabled = false;
            skeleton.transform.position = GameManager.instance.deposit.transform.position;
            grinder.myInterface.Atualiza();
        }
        Grind(skeleton); 
    }


    public void Grind(Skeleton skeleton)
    {
        Debug.Log("Grinding");
        if (grinder.bonesStored > 0)
        {
            GameManager.instance.AtualizaCalcio(Time.deltaTime * skeleton.grindingSpeed);
            grinder.bonesStored = grinder.bonesStored - (Time.deltaTime * skeleton.grindingSpeed) < 0? 0 : grinder.bonesStored - (Time.deltaTime * skeleton.grindingSpeed);
        }
    }

}
