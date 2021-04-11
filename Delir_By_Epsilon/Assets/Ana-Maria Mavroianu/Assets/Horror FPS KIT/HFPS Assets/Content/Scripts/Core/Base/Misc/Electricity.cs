/*
 * Electricity.cs - wirted by ThunderWire Games
 * ver. 2.0
*/

using UnityEngine;

public class Electricity : MonoBehaviour 
{

    public bool b_painTOuch = false;
    public GameObject nextObjective;

	private HFPS_GameManager gameManager;

    [Header("Hint")]
    public string offHint;
    public float hintTime;

    [Header("Indicator")]
	public GameObject LampIndicator;

    [SaveableField]
	public bool isPoweredOn = true;

	void Start()
	{
        gameManager = HFPS_GameManager.Instance;

        if (b_painTOuch) nextObjective.SetActive(false);
    }

	public void ShowOffHint()
	{
        gameManager.ShowHint (offHint, hintTime);
	}

	public void SwitchElectricity(bool power)
	{
		isPoweredOn = power;

        if (LampIndicator)
        {
            if (power)
            {
                LampIndicator.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(1f, 1f, 1f));
                LampIndicator.GetComponentInChildren<Light>().enabled = true;
                if (b_painTOuch) nextObjective.SetActive(true);
            }
            else
            {
                LampIndicator.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
                LampIndicator.GetComponentInChildren<Light>().enabled = false;
            }
        }
	}
}