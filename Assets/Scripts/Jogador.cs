using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
	public static Jogador instancia;

	public GameObject projetilPrefab;

	public Transform direcaoProjetil;

	private void Awake()
	{
		if (instancia != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instancia = this;
			DontDestroyOnLoad(gameObject);
		}

		if (direcaoProjetil == null)
		{
			direcaoProjetil = transform;
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GameObject projetil = Instantiate(projetilPrefab);
			projetil.transform.position = direcaoProjetil.position;
			projetil.transform.forward = direcaoProjetil.forward;
		}
	}

	private void OnTriggerEnter(Collider colisor)
	{
		if (colisor.CompareTag("Zumbi"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
