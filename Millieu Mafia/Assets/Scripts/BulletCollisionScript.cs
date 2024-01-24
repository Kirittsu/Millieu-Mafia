using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionScript : MonoBehaviour
{
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		
		if (other.GetComponent<FactoryBehavior>() != null)
		{
			if (other.gameObject.CompareTag("Enemy") || other.transform.parent.gameObject.CompareTag("Enemy"))
			{
				other.GetComponent<FactoryBehavior>().TakeDamage(1);
				Debug.Log("Enemy Hit");
				Destroy(gameObject);

			}
		}
	}
}
