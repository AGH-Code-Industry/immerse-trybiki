using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGearQueueDisplay : MonoBehaviour
{
    [SerializeField]
    private Image topGearImage;
    [SerializeField]
    private Image middleGearImage;
    [SerializeField]
    private Image bottomGearImage;

    [SerializeField] private Color nullColor;
    [SerializeField] private Color spriteColor;
    public void SetGearImages(List<GameObject> gearSet) {
        for (int i = 0; i < 3; i++) {
            Sprite inputSprite = i < gearSet.Count ? gearSet[i].GetComponent<SpriteRenderer>().sprite : null;
            Color colorToSet =  i < gearSet.Count ? spriteColor : nullColor;
            switch (i) {
                case 0:
                    topGearImage.sprite = inputSprite;
                    topGearImage.color = colorToSet;
                    break;
                case 1:
                    middleGearImage.sprite = inputSprite;
                    middleGearImage.color = colorToSet;
                    break;
                case 2:
                    bottomGearImage.sprite = inputSprite;
                    bottomGearImage.color = colorToSet;
                    break;
                default:
                    break;
            }
        }
    }
}
