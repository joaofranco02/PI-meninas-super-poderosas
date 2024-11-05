using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    // Nome da cena para a qual o botão deve mudar
    public string nomeDaCena;

    // Função para ser chamada ao clicar no botão
    public void MudarDeCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }


}
