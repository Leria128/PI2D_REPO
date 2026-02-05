using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCombinación : MonoBehaviour
{
    private string combinacionCorrecta = "1997";
    private string combinacionPlayer = "";
    private int numeroMaxDigitos = 0;

    public void EscribirCombinacion (string numero)
    {
        numeroMaxDigitos++;
        combinacionPlayer += numero;
        Debug.Log(combinacionPlayer);
        if(numeroMaxDigitos == 4)
        {
            if(combinacionPlayer == combinacionCorrecta)
            {
                Debug.Log("Combinación correcta! Es " + combinacionPlayer);
            }
            else
            {
                combinacionPlayer = "";
                numeroMaxDigitos = 0;
                Debug.Log("combinacion correcta");
            }
        }
    }


}
