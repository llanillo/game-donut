using System.Collections.Generic;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCanvas
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private RectTransform initialHearthLocation;
        [SerializeField] private GameObject fullHeart;
        [SerializeField] private GameObject almostHeart;
        [SerializeField] private GameObject emptyHeart;
        [SerializeField] private TextMeshProUGUI ammoText;
        
        private Sprite almostHeartSprite;
        private Sprite emptyHeartSprite;

        private Sprite fullHeartSprite;

        private List<GameObject> heartsList;
        private int lastHeart;

        private float offsetY;
        private PlayerManager playerManager;

        public void Startup()
        {
            CalculateHeartsOffset();
            
            heartsList = new List<GameObject>();

            playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
            playerManager.Health.HeartsDelegate += ReduceHearts;

            lastHeart = (int)playerManager.Health.MaxHealth - 1;

            fullHeartSprite = fullHeart.GetComponent<Image>().sprite;
            almostHeartSprite = almostHeart.GetComponent<Image>().sprite;
            emptyHeartSprite = emptyHeart.GetComponent<Image>().sprite;
            
            InitialHearts();
        }

        private void InitialHearts()
        {
            var maxHearts = playerManager.Health.MaxHealth;
            var lastPosition = initialHearthLocation;

            for (var i = 0; i < maxHearts; i++)
                if (i == 0)
                {
                    var heart = Instantiate(fullHeart, lastPosition, false);
                    lastPosition = heart.GetComponent<RectTransform>();
                    heartsList.Add(heart);
                }
                else
                {
                    var heart = Instantiate(fullHeart, lastPosition.position + Vector3.right * offsetY,
                        fullHeart.transform.rotation, initialHearthLocation);
                    lastPosition = heart.GetComponent<RectTransform>();
                    heartsList.Add(heart);
                }
        }

        private void ReduceHearts(float damage)
        {
            var count = (int)(damage / 0.5f);

            for (var i = 0; i < count; i++)
                if (lastHeart >= 0) // To prevent out of index error
                {
                    var heartImage = heartsList[lastHeart].GetComponent<Image>().sprite;

                    if (heartImage == fullHeartSprite)
                    {
                        heartsList[lastHeart].GetComponent<Image>().sprite = almostHeartSprite;
                    }

                    else
                    {
                        heartsList[lastHeart].GetComponent<Image>().sprite = emptyHeartSprite;
                        lastHeart -= 1;
                    }
                }
        }

        public void UpdateAmmo()
        {
            var weapon = playerManager.Weapon;
            if (weapon.CurrentWeapon != null)
                ammoText.SetText("Ammo: " + weapon.CurrentWeapon.data.currentAmmo + "/" +
                                 weapon.CurrentWeapon.data.maxAmmo);
        }

        private void CalculateHeartsOffset()
        {
            var width = Screen.width;

            if (width <= 1370)
                offsetY = 65;
            else if (width <= 1920)
                offsetY = 70;
            else if (width <= 3900)
                offsetY = 75;
        }
    }
}