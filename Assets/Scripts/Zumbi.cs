using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
	public Animator animator;
	public new Rigidbody rigidbody;

	private Transform jogador;

	public float velocidade = 0.35f;
	public float delayAndar = 2f;
	public float delayRecuperacao = 1f;
	public float delayMorrer = 3f;
	public int vidas = 1;

	private bool andando;

	private void Start()
	{
		jogador = GameObject.Find("Jogador").transform;

		transform.LookAt(jogador.transform);

		Invoke("Andar", delayAndar);
	}

	private void Andar()
	{
		andando = true;
	}

	private void FixedUpdate()
	{
		if (andando)
		{
			rigidbody.velocity = (jogador.position - transform.position).normalized * velocidade;
		}
	}

	public void Morrer()
	{
		rigidbody.velocity = Vector3.zero;
		andando = false;
		animator.SetTrigger("Die");
		Destroy(gameObject, delayMorrer);
	}

	public void CausarDano()
	{
		vidas--;
		animator.SetTrigger("Damage");
		rigidbody.velocity = Vector3.zero;
		andando = false;
		Invoke("Andar", delayRecuperacao);
	}

	private void OnTriggerEnter(Collider colisor)
	{
		if (andando && colisor.CompareTag("Projetil"))
		{
			if (vidas == 0)
			{
				Morrer();
				Destroy(colisor.gameObject);
			}
			else
			{
				CausarDano();
			}
		}
	}
}
