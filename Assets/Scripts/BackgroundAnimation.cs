using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnimation : MonoBehaviour
{
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
        Image image = obj.GetComponent<Image>();
        RectTransform rect = image.GetComponent<RectTransform>();
        image.rectTransform.sizeDelta = new Vector2 ((float) (image.sprite.rect.width * 0.5),(float) (image.sprite.rect.height * 0.5));
       
    }
}
