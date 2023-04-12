using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
   public void AfficherInstructions()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }

   
}
