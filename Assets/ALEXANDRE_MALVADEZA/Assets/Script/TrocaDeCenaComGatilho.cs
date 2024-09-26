using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCenaComGatilho : MonoBehaviour
{
    // Nome da cena que ser� carregada
    public string cena2;

    // Fun��o chamada quando outro Collider entra no gatilho
    private void OnTriggerEnter(Collider outro)
    {
        // Verifica se o objeto que entrou no gatilho tem a tag "Player"
        if (outro.CompareTag("Play"))
        {
            // Troca para a cena especificada
            SceneManager.LoadScene(cena2);
        }
    }
}
