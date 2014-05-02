using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;
	private Done_PlayerHealth Health;
	public float damageAmount = 1f;			// The amount of damage to take when enemies touch the player



	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		GameObject HealthObject = GameObject.FindGameObjectWithTag ("Player");

		if (HealthObject != null)
		{
			Health = HealthObject.GetComponent <Done_PlayerHealth>();
		}
		if (Health == null)
		{
			Debug.Log ("Cannot find 'Player' script");
		}

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion != null)
		{
			if (other.tag == "Player")
			{
				if(Health.health > 0f)
				{
					// ... take damage and reset the lastHitTime.
					Health.health -= damageAmount;
					Destroy (gameObject);
					Debug.Log(Health.health);
					if (Health.health == 0f)
					{
						Destroy (other.gameObject);
						Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
						gameController.GameOver();
					}
					
				}
				else
				{
					//yourOtherObject.GetComponent<YourScriptOfOtherObject>().yourMethod( method input variables);
					Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
					gameController.GameOver();
				}
			}
			else
				Destroy (other.gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
//			float Value;
//			Value = Health.health;
				if(Health.health > 0f)
				{
					// ... take damage and reset the lastHitTime.
					Health.health -= damageAmount;
					Destroy (gameObject);
					Debug.Log(Health.health);
					if (Health.health == 0f)
					{
					Destroy (other.gameObject);
					Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
					gameController.GameOver();
					}

				}
				else
				{
					//yourOtherObject.GetComponent<YourScriptOfOtherObject>().yourMethod( method input variables);
					Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
					gameController.GameOver();
				}
		}
		gameController.AddScore(scoreValue);
		Destroy (gameObject);
	}
}