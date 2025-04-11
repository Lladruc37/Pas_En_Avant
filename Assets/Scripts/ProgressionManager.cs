using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		profileHolders = new ProfileHolder[3];
	}

	private void OnEnable()
	{
		UpdateProfile();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void UpdateProfile()
	{
		for (int i = 0; i < profileHolders.Length; i++)
		{
			ProfileHolder profileHolder = profileHolders[i];
			profileHolder.UpdateProfile(dataManager.SelectedProfiles[i], dataManager.CurrentLanguage);
		}
	}

	public ProfileHolder[] profileHolders = null;
	public DataManager dataManager = null;
}
