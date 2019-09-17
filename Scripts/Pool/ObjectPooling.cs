using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
	[System.Serializable]
	public class ObjetosClass
	{
		public GameObject prefab;
		public int quatidade;
	}

	public ObjetosClass[] objetos;
	List<GameObject> listObjetos;
	int somaObjetos;

	#region Singleton
	public static ObjectPooling instance;
	private void Awake()
	{
		instance = this;
	}
	#endregion

	void Start()
	{
		listObjetos = new List<GameObject>();

		for (int i = 0; i < objetos.Length; i++)
		{
			for (int j = 0; j < objetos[i].quatidade; j++)
			{
				GameObject objInstantiate = Instantiate(objetos[i].prefab, transform.position, Quaternion.identity, transform);
				objInstantiate.SetActive(false);
				listObjetos.Add(objInstantiate);
			}
		}
	}

	public GameObject SpawObjetos(string nome, Transform posicao) // variavel nome deve ser o nome do prefab que vai ser instanciado.
	{
		foreach (GameObject inimigo in listObjetos)
		{
			if (!inimigo.activeInHierarchy)
			{
				if (inimigo.name == nome)
				{
					inimigo.transform.position = posicao.position;
					inimigo.SetActive(true);
					return inimigo;
				}
			}
		}
		return null;
	}
}