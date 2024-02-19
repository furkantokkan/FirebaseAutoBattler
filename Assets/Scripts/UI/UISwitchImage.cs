using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISwitchImage : MonoBehaviour
{
    public Image backgroundImage;
    public float ChangeInterval = 1.0f;
    public float stayDuration = 5f;
    public Sprite[] sprites;

    int currentImageIndex = -1;

    private void Awake()
    {
        if (backgroundImage == null)
        {
            backgroundImage = GetComponent<Image>();
        }

        StartCoroutine(SwitchImages());
    }

    private IEnumerator SwitchImages()
    {
        while (gameObject.activeInHierarchy)
        {
            int index = -1;

            do
            {
                index = UnityEngine.Random.Range(0, sprites.Length);
                yield return null;

            } while (index == currentImageIndex);

            currentImageIndex = index;

            backgroundImage.DOColor(Color.black, ChangeInterval);

            yield return new WaitForSeconds(ChangeInterval);

            backgroundImage.sprite = sprites[currentImageIndex];

            backgroundImage.DOColor(Color.white, ChangeInterval);

            yield return new WaitForSeconds(stayDuration);
        }
    }
}
