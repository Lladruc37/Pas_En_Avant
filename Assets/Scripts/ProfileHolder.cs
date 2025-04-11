using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DataManager;

public class ProfileHolder : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void UpdateProfile(Profile profile, LANGUAGE language)
	{
		Profile = profile;
		// TODO: ADD PROFILE DATA
		Texture.sprite = Profile.Image;

		if (Description == null)
			return;

		var description = "";
		switch (language)
		{
			case LANGUAGE.ENG:
				description = Profile.EnglishDescription;
				break;
			case LANGUAGE.FRE:
				description = Profile.FrenchDescription;
				break;
			default:
				break;
		}
		Description.text = description;
	}

	private Profile Profile = null;

	public Image Texture = null;
	public TextMeshProUGUI Description = null;
}
