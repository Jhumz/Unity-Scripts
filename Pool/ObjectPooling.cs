using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

	//Basico para spawn por tempo no local desse script.. Pode ser ajusto de varias formas.

	[SerializeField] int quantidade;
	[SerializeField] float tempoEntreSpawn;
	public GameObject[] objetos;
	List<GameObject> listObjetos;
	float tempo;
	int randon; // Criar objetos randomicos

	void Awake () {

		listObjetos = new List<GameObject>(quantidade);
		for (int i = 0; i < quantidade; i++)
		{
			randon = Random.Range(0, objetos.Length);
			GameObject spiritInstance = Instantiate(objetos[randon], transform.position, Quaternion.identity);
			spiritInstance.transform.SetParent(transform);
			spiritInstance.SetActive(false);
			listObjetos.Add(spiritInstance);
		}
	}
	
	void Update () {
		
		tempo += Time.deltaTime;
		if (tempo >= tempoEntreSpawn)
		{
			SpawInimigos();
			tempo = 0;
		}
	}

	public GameObject SpawInimigos() // Metodo para spawn dos objetos
	{
		foreach (GameObject inimigo in listObjetos)
		{
			if (!inimigo.activeInHierarchy)
			{
				inimigo.transform.position = transform.position;
				inimigo.SetActive(true);
				return inimigo;
			}
		}
		return null;
	}
}
