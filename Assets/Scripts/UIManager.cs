using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private Text currentHealthPoint;
        [SerializeField] private Text currentAmmoAmount;


        public void HealthPointText(float healthPoint)
        {
            currentHealthPoint.text = healthPoint.ToString();
        }

        public void AmmoAmountText(string ammoAmount)
        {
            currentAmmoAmount.text = ammoAmount;
        }
    }
}