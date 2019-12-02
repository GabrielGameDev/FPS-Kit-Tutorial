using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
	public Target[] enemies;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SetEnemies(true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SetEnemies(false);
		}
	}

	void SetEnemies(bool state)
	{
		for (int i = 0; i < enemies.Length; i++)
		{
			enemies[i].followingPlayer = state;
		}
	}
}
