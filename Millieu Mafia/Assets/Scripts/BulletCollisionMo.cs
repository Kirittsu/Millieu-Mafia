using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionMo : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{

		if (other.GetComponent<Enemy>() != null)
		{
			if (other.gameObject.CompareTag("Enemy") || other.transform.parent.gameObject.CompareTag("Enemy"))
			{
				other.GetComponent<Enemy>().TakeDamage(5);
				Debug.Log("Enemy Hit");
				Destroy(gameObject);

			}
		}
	}
}
