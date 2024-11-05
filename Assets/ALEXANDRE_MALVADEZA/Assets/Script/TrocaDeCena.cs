using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    // Nome da cena para a qual o bot�o deve mudar
    public string nomeDaCena;

    // Fun��o para ser chamada ao clicar no bot�o
    public void MudarDeCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }


}
