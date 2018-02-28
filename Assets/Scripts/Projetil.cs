using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
	public float duracao = 10f;
	public float velocidade = 4f;

	private void Start()
	{
		Destroy(gameObject, duracao);
	}

	// Update is called once per frame
	private void Update()
	{
		transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
	}
}
