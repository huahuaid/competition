using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour
{
	public float minX;
	public float maxX;
	public float moveSpeed = 2f;

	private Vector3 targetPosition;
	private NPCStateMachine stateMachine;
	private npcTrigger npcTrigger;

	void Start()
	{
		npcTrigger = gameObject.GetComponent<npcTrigger>();
		stateMachine = gameObject.GetComponent<NPCStateMachine>();
		stateMachine = new NPCStateMachine(NPCStateMachine.NPCState.Idle);
		SetRandomTargetPosition();
	}

	void Update()
	{
		if (npcTrigger.isDialogue)
		{
			stateMachine.ChangeState(NPCStateMachine.NPCState.Dialogue);
		}
		switch (stateMachine.CurrentState)
		{
			case NPCStateMachine.NPCState.Idle:
				Idle();
				break;
			case NPCStateMachine.NPCState.Walk:
				Walk();
				break;
			case NPCStateMachine.NPCState.Filp:
				Filp();
				break;
			case NPCStateMachine.NPCState.Dialogue:
				Dialogue();
				break;
			default:
				Idle();
				break;
		}
	}

	private void Idle()
	{
		if (npcTrigger.isTargetNPC)
		{
			Filp();
		}
		else
		{
			StartCoroutine(WaitChangeWalkState());
		}
	}

	private void Walk()  
	{  

		npcTrigger.animator.SetBool("isWalk", true);

		if (targetPosition.x
				> gameObject.transform.position.x)
		{
			gameObject.transform.localScale = new Vector3(-1,1,1);
		}
		else
		{
			gameObject.transform.localScale = new Vector3(1,1,1);
		}

		transform.position = Vector3.MoveTowards(  
				transform.position,  
				targetPosition,  
				moveSpeed * Time.deltaTime);  

		if (Vector3.Distance(transform.position, targetPosition) < 0.1f)  
		{  
			SetRandomTargetPosition(); 
			stateMachine.ChangeState(NPCStateMachine.NPCState.Filp);
		}  

		if (npcTrigger.isTargetNPC)
		{
			stateMachine.ChangeState(NPCStateMachine.NPCState.Filp);
		}
	} 

	private void Filp(){
		npcTrigger.animator.SetBool("isWalk",false);
		if (npcTrigger.isTargetNPC)
		{
			if (npcTrigger.playerObject.transform.position.x
					> gameObject.transform.position.x)
			{
				gameObject.transform.localScale = new Vector3(-1,1,1);
			}
			else
			{
				gameObject.transform.localScale = new Vector3(1,1,1);
			}
		}

		if (!npcTrigger.isTargetNPC)
		{
			if (targetPosition.x
					> gameObject.transform.position.x)
			{
				gameObject.transform.localScale = new Vector3(-1,1,1);
			}
			else
			{
				gameObject.transform.localScale = new Vector3(1,1,1);
			}
			stateMachine.ChangeState(NPCStateMachine.NPCState.Idle);
		}
	}

	private void Dialogue(){
		if (!npcTrigger.isDialogue)
		{
			npcTrigger.animator.SetBool("isDialogue",false);
			stateMachine.ChangeState(NPCStateMachine.NPCState.Idle);
		}
		else{
			npcTrigger.animator.SetBool("isDialogue",true);
		}
	}

	private IEnumerator WaitChangeWalkState(){
		yield return new WaitForSeconds(1f);
		stateMachine.ChangeState(NPCStateMachine.NPCState.Walk);
	}

	private void SetRandomTargetPosition()  
	{  
		float randomX = Random.Range(minX, maxX);  
		targetPosition = new Vector3(randomX, transform.position.y, transform.position.z);  
	}
}
