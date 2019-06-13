using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text levelBar;
    public Text haulBar;
    public int level;
    public int distance;

    private void UpdateLevelBar()
    {
        if (levelBar is null) return;
        levelBar.text = level.ToString();
    }

    private void UpdateHaulBar()
    {
        if (haulBar is null) return;
        haulBar.text = distance.ToString("0");
    }
}