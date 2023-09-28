using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chimp_Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void Level1() {
     SceneManager.LoadScene("Chimp_L1");
   }
   public void Level2() {
     SceneManager.LoadScene("Chimp_L2");
   }
   public void Level3() {
     SceneManager.LoadScene("Chimp_L3");
   }
   public void Level4() {
     SceneManager.LoadScene("Chimp_L4");
   }
   public void Level5() {
     SceneManager.LoadScene("Chimp_L5");
   }
   public void Level6() {
     SceneManager.LoadScene("Chimp_L6");
   }

   public void LevelSelect() {
     SceneManager.LoadScene("Chimp_MainMenu");
   }


}
