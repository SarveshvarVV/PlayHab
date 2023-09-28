using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MC_SwitchToWhite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WhiteGo());
    }

    public IEnumerator WhiteGo()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MC_WAnswer");
    }
}
