using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 100;
	private int currentHealth;

	public Image damageImage;
	public Slider healthSlider;
	public Color damageColor;
	public float flashSpeed = 2;

	private bool damaged;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		if (damaged)
		{
			damageImage.color = damageColor;
		}
		else
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
    }

	public void TakeDamage(int damageAmount)
	{
		currentHealth -= damageAmount;
		healthSlider.value = currentHealth;
		damaged = true;
	}
}
