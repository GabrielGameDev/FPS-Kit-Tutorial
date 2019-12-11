using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 100;
	private int currentHealth;

	public Image damageImage;
	public Slider healthSlider;
	public Color damageColor;
	public float flashSpeed = 2;

	private bool damaged;
	private bool isDead;

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
		else if(!damaged && !isDead)
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		else if (isDead)
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.black, flashSpeed * Time.deltaTime);
		}
		damaged = false;
    }

	public void TakeDamage(int damageAmount)
	{
		if (isDead)
			return;

		currentHealth -= damageAmount;
		healthSlider.value = currentHealth;
		damaged = true;

		if(currentHealth <= 0)
		{
			isDead = true;
			Invoke("Death", 3f);
		}
	}

	void Death()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
