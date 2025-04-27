using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
	public ScoreManager scoreManager;
	public GameManager gameManager;

	private int woodWeight = 5;
	private int stoneWeight = 5;
	private int bambooWeight = 2; // ��������Ϊ1

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other == null) return;

		if (other.CompareTag("Wood") || other.CompareTag("Stone") || other.CompareTag("Bamboo"))
		{
			// ������������ʵ��
			if (other.gameObject.scene.IsValid())
			{
				Destroy(other.gameObject);
			}

			// ִ�ж�Ӧ�߼�
			if (other.CompareTag("Wood"))
			{
				scoreManager?.AddWoodWeight(woodWeight);
				scoreManager?.AddBagWholeWeight(woodWeight);
			}
			else if (other.CompareTag("Stone"))
			{
				scoreManager?.AddBagWholeWeight(stoneWeight);
			}
			else if (other.CompareTag("Bamboo"))
			{
				scoreManager?.AddBambooWeight(bambooWeight);
				scoreManager?.AddBagWholeWeight(bambooWeight);
			}
		}
	}
}
