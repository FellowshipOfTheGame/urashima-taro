using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
   
    public static bool eventoChave = true;//passar para false quando entrar em produção
    public static bool insereChave = true;
    public static bool porta       = false;
    private static bool ataque = false;
    private static int  fantasmaAtaque = 3;

    public static Flag instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void setFantasmaAtaque(int value)
      {
      
         fantasmaAtaque -= value;
      
      }
      
    public int getFantasmaAtaque()
      {
      
         return fantasmaAtaque;
      
      }
      
    public void setAtaque(bool value)
      {
      
         ataque = value;
      
      }
      
    public bool getAtaque()
      {
      
         return ataque;
      
      }

}
