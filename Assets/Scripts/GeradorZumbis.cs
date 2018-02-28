using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
	public GameObject zumbiPrefab;

	public float intervalo = 4f;
	public float area = 5f;

	private void Start()
	{
		InvokeRepeating("GerarZumbi", 0f, intervalo);
	}

	private void GerarZumbi()
	{
		GameObject zumbi = Instantiate(zumbiPrefab);
		Vector2 posicaoAleatoria = Random.insideUnitCircle.normalized * area;
		zumbi.transform.position =
			new Vector3(
				posicaoAleatoria.x,
				0f,
				posicaoAleatoria.y
			);
	}
}
