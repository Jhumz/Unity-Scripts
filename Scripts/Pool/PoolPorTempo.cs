using System.Collections.Generic;
using UnityEngine;

public class PoolPorTempo : MonoBehaviour {

	//Basico para spawn por tempo no local desse script.. Pode ser ajusto de varias formas.

	[SerializeField] int quantidade;
	[SerializeField] float tempoEntreSpawn;
	public GameObject[] objetos; //Quanto mais obj do mesmo tipo mais chances de spawn.
	List<GameObject> listObjetos;
	float tempo;
	int randon; // Criar objetos randomicos

	void Awake () {

		listObjetos = new List<GameObject>(quantidade);
		for (int i = 0; i < quantidade; i++)
		{
			randon = Random.Range(0, objetos.Length);
			GameObject obj = Instantiate(objetos[randon], transform.position, Quaternion.identity, transform);
			obj.SetActive(false);
			listObjetos.Add(obj);
		}
	}
	
	void Update () {
		
		tempo += Time.deltaTime;
		if (tempo >= tempoEntreSpawn)
		{
			Spawn();
			tempo = 0;
		}
	}

	public GameObject Spawn() // Metodo para spawn dos objetos
	{
		foreach (GameObject obj in listObjetos)
		{
			if (!obj.activeInHierarchy)
			{
				obj.transform.position = transform.position;
				obj.SetActive(true);
				return obj;
			}
		}
		return null;
	}
}
