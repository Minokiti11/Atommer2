using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
	Material material;

	bool dissolve = false;
	bool appear = true;
	float fade = 1f;

	void Start()
	{
		material = GetComponent<SpriteRenderer>().material;
		fade = 0f;
		material.SetFloat("_Fade", fade);
		appear = true;
	}

	void Update()
    {
        // if ()
		// {
		// 	dissolve = true;
		// }

        // if ()
		// {
		// 	appear = true;
		// }

		if (dissolve)
		{
			fade -= Time.deltaTime;

			if (fade <= 0f)
			{
				fade = 0f;
				dissolve = false;
			}

			// Set the property
			material.SetFloat("_Fade", fade);
		}

		if (appear)
		{
			fade += Time.deltaTime;

			if (fade >= 1f)
			{
				fade = 1f;
				appear = false;
			}

			// Set the property
			material.SetFloat("_Fade", fade);
		}
    }
}
