using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiPanel : MonoBehaviour
{
    [Header("Inscribed")]
    public Sprite healthEmpty;
    public Sprite healthHalf;
    public Sprite healthFull;

    Text keyCountText;
    Text goldCountText;
    List<Image> healthImages;

    void Start()
    {
        // Key Count
        Transform trans = transform.Find("Key Count");                            // b
        keyCountText = trans.GetComponent<Text>();

        Transform trans1 = transform.Find("Gold Count");
        goldCountText = trans1.GetComponent<Text>();
        // Health Icons
        Transform healthPanel = transform.Find("Health Panel");
        healthImages = new List<Image>();
        if (healthPanel != null)
        {                                                // c
            for (int i = 0; i < 20; i++)
            {
                trans = healthPanel.Find("H_" + i);
                if (trans == null) break;
                healthImages.Add(trans.GetComponent<Image>());
            }
        }
    }

    void Update()
    {
        // Show keys                                
        keyCountText.text = Dray.NUM_KEYS.ToString();
        // d
        goldCountText.text = Dray.NUM_GOLD.ToString();

        // Show health
        int healthDisp = Dray.HEALTH;
        for (int i = 0; i < healthImages.Count; i++)
        {                                // e
            if (healthDisp > 1)
            {
                healthImages[i].sprite = healthFull;
            }
            else if (healthDisp == 1)
            {
                healthImages[i].sprite = healthHalf;
            }
            else
            {
                healthImages[i].sprite = healthEmpty;
            }
            healthDisp -= 2;
        }
    }
}