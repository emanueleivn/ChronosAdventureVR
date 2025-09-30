using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    public void CaricaScena(string nomeScena)
    {
        if (string.IsNullOrEmpty(nomeScena))
        {
            Debug.LogWarning("ButtonSceneLoader: nomeScena vuoto.");
            return;
        }
        SceneManager.LoadScene(nomeScena);
    }
    public void CaricaScenaPerIndice(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void CaricaScenaAsync(string nomeScena)
    {
        StartCoroutine(CaricaAsyncCoroutine(nomeScena));
    }

    private IEnumerator CaricaAsyncCoroutine(string nome)
    {
        var op = SceneManager.LoadSceneAsync(nome);
        while (!op.isDone)
        {
            yield return null;
        }
    }
}
