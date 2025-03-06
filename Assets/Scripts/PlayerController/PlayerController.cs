using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float nextLevelPosition;
	public float preLevelPosition;

	public float moveSpeed = 1f;
	public Rigidbody2D player;
	private Vector2 movement;

	NextLevelScence nextLevelScence = new NextLevelScence();

	void Start()
	{
	}

	void Update()
	{
		Walk();
	}

	void Walk(){
		float moveDir = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2(moveDir, player.velocity.y);
		player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
