using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChonkStateABBF : StateABBF
{
    public ChonkStateABBF(ABunchOfBoxesOnTheFloorSC stateController) : base(stateController) { }
    

    public override void Act()
    {
        if (stateController.enemyToChase != null)
        {
            stateController.destination = stateController.enemyToChase.transform;
            stateController.ai.SetTarget(stateController.destination);
        }
    }

    public override void CheckTransitions()
    {
        if (!stateController.CheckIfInRange("Player"))
        {
            stateController.gameObject.transform.localScale = new Vector3(1, 1, 1);
            stateController.SetState(new WanderStateABBF(stateController));
        }
    }

    public override void OnStateEnter()
    {
        stateController.ChangeColor(Color.green);
        stateController.gameObject.transform.localScale = new Vector3(2, 1, 2);
        stateController.ai.agent.speed = .25f;
    }
}
