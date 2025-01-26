using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandleMovement : MonoBehaviour
{
    public Slider slider;
    public GameObject prefabToInstantiate;

    private float lastValue = -1f;  // Son deðeri saklamak için
    private float threshold = 0.05f; // Minimum deðiþim eþiði
    private void Start()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // Eðer deðerdeki deðiþim eþiði belirli bir sýnýrýn altýndaysa iþlem yapma
        if (Mathf.Abs(value - lastValue) < threshold)
        {
            return;  // Eþik deðerin altýndaki deðiþiklikler göz ardý edilir
        }

        lastValue = value;  // Son deðeri güncelle

        Debug.Log("Slider deðeri deðiþti: " + value);
        if (prefabToInstantiate != null)
        {
            Vector3 spawnPosition = transform.position;
            Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
            Debug.Log("Prefab oluþturuldu!");
        }
    }
}

