using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BulletUI : MonoBehaviour
{
    public List<Image> bulletImages; // List of UI Image components for bullets
    public Sprite filledBullet; // The image for a filled bullet
    public Sprite emptyBullet; // The image for an empty bullet

    private int currentBullets; // Current bullets remaining
    public int maxBullets = 5;

    void Start()
    {
        currentBullets = maxBullets;
        UpdateBulletUI();
    }

    void Shoot()
    {
        if (currentBullets > 0)
        {
            currentBullets--;
            UpdateBulletUI();
            // Your shooting logic here
        }
        else
        {
            // Handle running out of bullets
        }
    }

    void UpdateBulletUI()
    {
        // Update the displayed images based on the current bullets
        for (int i = 0; i < bulletImages.Count; i++)
        {
            if (i < currentBullets)
            {
                bulletImages[i].sprite = filledBullet;
            }
            else
            {
                bulletImages[i].sprite = emptyBullet;
            }
        }
    }
}
