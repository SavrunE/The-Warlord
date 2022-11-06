using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_InputField))]
public class ButtonActivator : MonoBehaviour
{
    private TMP_InputField inputField;
    
    [SerializeField] private float waitTimeAlbedo;
    [SerializeField] private Button[] buttons;

    private float timer = 0f;
    private bool canShowButton = true;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (inputField.text.Length > 0 && canShowButton)
        {
            canShowButton = false;
            ShowButton();
        }
    }

    private void ShowButton()
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(true);
        }
        ChangeButtonAlbedo(0f);
        StartCoroutine(IncreaseAlbedo());
    }

    private IEnumerator IncreaseAlbedo()
    {
        float maxAlbedo = 1f;
        while (buttons[0].image.color.a != maxAlbedo)
        {
            yield return null;
            timer += Time.deltaTime;
            if (timer < waitTimeAlbedo)
            {
                ChangeButtonAlbedo(timer/ waitTimeAlbedo);
            }
            else
            {
                ChangeButtonAlbedo(maxAlbedo);
                StopCoroutine(IncreaseAlbedo());
            }
        }
    }

    private void ChangeButtonAlbedo(float albedo)
    {
        foreach (var button in buttons)
        {
        Color buttonColor = button.image.color;
        button.image.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, albedo);
        }
    }
}
