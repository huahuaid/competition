using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target;
	public float smoothing = 0.5f;

	public Vector2 minPosition;
	public Vector2 maxPosition;

	private bool isFollowing = true;

	void Start()
	{
		if (target != null)
		{
			Vector3 startPos = target.position;
			startPos.x = Mathf.Clamp(startPos.x, minPosition.x, maxPosition.x);
			startPos.y = Mathf.Clamp(startPos.y, minPosition.y, maxPosition.y);
			startPos.z = -10f;
			transform.position = startPos;
		}
	}

	private void LateUpdate()
	{
		if (target != null)
		{
			Vector3 targetPos = target.position;
			targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
			targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
			targetPos.z = -10f;

			if (targetPos.x >= maxPosition.x )
			{
				isFollowing = false;
			}
			else
			{
				isFollowing = true;
			}

			if (isFollowing)
			{
				transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
			}
		}
	}

	public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
	{
		minPosition = minPos;
		maxPosition = maxPos;
	}
}

