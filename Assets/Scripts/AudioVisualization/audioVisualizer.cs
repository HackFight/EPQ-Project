using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audioVisualizer : MonoBehaviour
{
    public GameObject cubePrefab;
    private GameObject[] cubes = new GameObject[512];

    public float circleRadius = 20f;
    public float maxBarsHeight = 5f;

    private AudioSource audioSource;
    public static float[] samples = new float[512];

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instance = Instantiate(cubePrefab, this.transform);
            instance.transform.position = this.transform.position;
            instance.name = "SampleCube_" + i;
            this.transform.eulerAngles = new Vector3(0f, -0.703125f * i, 0f);
            instance.transform.position = Vector3.forward * circleRadius;
            cubes[i] = instance;
        }
    }

    private void Update()
    {
        GetSpectrumAudioSource();

        for (int i = 0;i < 512; i++)
        {
            if (cubes[i] != null)
            {
                cubes[i].transform.localScale = new Vector3(0.1f, samples[i] * maxBarsHeight, 0.1f);
            }
        }
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
