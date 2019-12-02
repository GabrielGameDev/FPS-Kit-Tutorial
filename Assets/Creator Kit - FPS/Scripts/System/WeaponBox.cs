using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
	public Weapon weapon;

	private void OnTriggerEnter(Collider other)
	{
		Controller player = other.GetComponent<Controller>();
		if(player != null)
		{
			player.PickupWeapon(weapon);
			Destroy(gameObject);
		}
	}

}
