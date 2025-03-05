using UnityEngine; using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float nextLevelPosition;
	public float preLevelPosition;
	public Image mainPlane;
	public Image dialogueButton;
	public float moveSpeed = 1f;
	public Rigidbody2D player;
	private Vector2 movement;

	private bool isDialogue;
	private bool toggleDialoguePlane;

	NextLevelScence nextLevelScence = new NextLevelScence();

	void Start()
	{
	}

	void Update()
	{
		Walk();
		Dialogue();
		NextScene();
	}

	void Dialogue(){
		if (Input.GetKeyDown(KeyCode.E) && isDialogue)
		{
			mainPlane.gameObject.SetActive(!toggleDialoguePlane);
			dialogueButton.gameObject.SetActive(toggleDialoguePlane);
			toggleDialoguePlane = !toggleDialoguePlane;
		}
	}

	void Walk(){
		float moveDir = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2(moveDir, player.velocity.y);
		player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
	}

void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("NPC"))
		{
			dialogueButton.gameObject.SetActive(true);
			isDialogue = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("NPC"))
		{
			dialogueButton.gameObject.SetActive(false);
			isDialogue = false;
		}
	}

	void NextScene(){
		if(player.position.x >= nextLevelPosition){
			nextLevelScence.LoadNextScene();
			player.position = new Vector2(-2f, player.position.y);
		}
		else if(player.position.x <= preLevelPosition){
			nextLevelScence.LoadPreScene();
			player.position = new Vector2(7f, player.position.y);
		}
	}
}
