using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour {
    private const float FLASH_DURATION = .1f;
    private static Color FLASH_COLOR;

    void Start() {
        FLASH_COLOR = new Color(1f, 1f, 1f, 0.35f);
    }

    public static IEnumerator FlashSprite(GameObject sprite) {
        Debug.Log("Flashing sprites");
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        Color originalColor = renderer.material.color;
        
        renderer.material.color = FLASH_COLOR;
        yield return new WaitForSeconds(FLASH_DURATION);
        renderer.material.color = originalColor;

        yield return 0;
    }
}
