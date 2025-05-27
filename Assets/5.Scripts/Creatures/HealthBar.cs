using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer foreground;

    private float initialWidth;

    private void Awake()
    {
        if (foreground == null)
        {
            Debug.LogError("HealthBar: Foreground SpriteRenderer를 연결하세요!");
            return;
        }
        initialWidth = foreground.transform.localScale.x;
        SetHealthRatio(1f);
    }

    /// <summary>
    ///  체력 비율(current / max)을 0~1로 받아서 Foreground 스케일을 조절
    /// </summary>
    public void SetHealthRatio(float ratio)
    {
        ratio = Mathf.Clamp01(ratio);
        Vector3 scale = foreground.transform.localScale;
        scale.x = initialWidth * ratio;
        foreground.transform.localScale = scale;
    }
}
