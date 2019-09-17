using UnityEngine;

public class CameraSegue : MonoBehaviour {

	[SerializeField] Transform alvo; 
	[SerializeField] float velocidadeSuave = 30f; 
	[SerializeField] Vector3 deslocamento; 
	Vector3 posicaoDesejada; 
	Vector3 posicaoSuavizada; 
	Vector3 velocidade = Vector3.zero;

	void LateUpdate() 
	{
		posicaoDesejada = alvo.position + deslocamento;
		posicaoSuavizada = Vector3.SmoothDamp(transform.position, posicaoDesejada, ref velocidade, velocidadeSuave * Time.deltaTime);
		transform.position = posicaoSuavizada;
	}
}
