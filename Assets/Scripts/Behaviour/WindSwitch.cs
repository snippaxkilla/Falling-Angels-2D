using UnityEngine;

public class WindSwitch : MonoBehaviour
{
    public bool isSwitchUsed;
    public bool WindSwitched;
    public WindSwitchCheck switchCheck;
    public AudioSource WindOnOff;
    private AreaEffector2D areaEffector2;
    private ParticleSystem pSystem;
    private ParticleSystemRenderer pSystemRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        areaEffector2 = GetComponent<AreaEffector2D>();
        pSystemRenderer = GetComponent<ParticleSystemRenderer>();

        pSystem.Play();
        areaEffector2.enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        WindOnOff.Play();
        if (switchCheck.Switched == false)
        {
            pSystemRenderer.enabled = false;
            pSystem.Pause();
            areaEffector2.enabled = false;
        }

        else
        {
            pSystemRenderer.enabled = true;
            pSystem.Play();
            areaEffector2.enabled = true;
        }
    }
}