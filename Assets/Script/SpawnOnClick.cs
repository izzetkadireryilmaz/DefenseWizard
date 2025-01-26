using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandleMovement : MonoBehaviour
{
    public Slider slider;
    public GameObject prefabToInstantiate;

    private float lastValue = -1f;  // Son de�eri saklamak i�in
    private float threshold = 0.05f; // Minimum de�i�im e�i�i
    private void Start()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // E�er de�erdeki de�i�im e�i�i belirli bir s�n�r�n alt�ndaysa i�lem yapma
        if (Mathf.Abs(value - lastValue) < threshold)
        {
            return;  // E�ik de�erin alt�ndaki de�i�iklikler g�z ard� edilir
        }

        lastValue = value;  // Son de�eri g�ncelle

        Debug.Log("Slider de�eri de�i�ti: " + value);
        if (prefabToInstantiate != null)
        {
            Vector3 spawnPosition = transform.position;
            Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
            Debug.Log("Prefab olu�turuldu!");
        }
    }
}

