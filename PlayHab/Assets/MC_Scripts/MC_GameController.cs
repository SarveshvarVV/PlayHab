using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MC_GameController : MonoBehaviour
{
    public static MC_GameController instance;

    public List<Image> imazes;
    public List<Sprite> sprites;

    int imazecount;
    int spritenum;
    int imazenum;

    public int white;
    public int black;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < imazes.Count; i++)
        {
            spritenum = Random.Range(0, sprites.Count);
            if (spritenum == 0)
            {
                white += 1;
            }
            else
            {
                black += 1;
            }
            imazes[i].sprite = sprites[spritenum];

        }
        StartCoroutine(Waitpannu());
    }


    public IEnumerator Waitpannu()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("MC_BAnswer");

    }

  
}
