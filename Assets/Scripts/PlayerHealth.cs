using Unity.Mathematics.Geometry;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public int currentHealth;
   public int maxHealth;

   public void ChangeHealth(int amount)
   {
      currentHealth += amount;
      System.Math.Clamp(currentHealth, 0, maxHealth);
   }
}
