using System.Collections;
using UnityEngine;

public class EnemyAI_Police : EnemyAI
{
    public Rigidbody policeBody;
    public override void AttackAction()
    {
        //Dive into player

        agent.enabled = false;
        policeBody.isKinematic = false;
        policeBody.AddForce(transform.forward * 32f, ForceMode.Impulse);
        StartCoroutine(Recover());

        Debug.Log("Police Attacks!");
    }

    private IEnumerator Recover()
    {
        yield return new WaitUntil(() => policeBody.linearVelocity.magnitude < 0.1f);
        agent.enabled = true;
        policeBody.isKinematic = true;
    }
}
