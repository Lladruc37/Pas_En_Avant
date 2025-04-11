using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		SelectedScene = Selection;
	}

	// Update is called once per frame
	void Update()
	{
		if (DataManager == null || playerInput == null)
			return;

		if (SelectedScene == Selection)
		{
			if (playerInput.actions["submit"].WasReleasedThisFrame())
			{
				MoveToScene(Progression);
				DataManager.CurrentQuestion = 0;
				UpdateQuestion();
			}
		}
		else if (SelectedScene == Progression)
		{
			if (playerInput.actions["submit"].WasReleasedThisFrame())
			{
				//TODO: IF LAST QUESTION GO TO TABLE
				if ((DataManager.MAX_QUESTIONS - 1) == DataManager.CurrentQuestion)
				{
					MoveToScene(Results);
					UpdateFinalText();
				}
				else //TODO: UPDATE QUESTION
				{
					DataManager.CurrentQuestion += 1;
					UpdateQuestion();
				}
			}
		}
		else if (SelectedScene == Results)
		{
			if (playerInput.actions["submit"].WasReleasedThisFrame())
			{
				Application.Quit();
			}
		}
	}

	public void UpdateQuestion()
	{
		var question = "";
		switch (DataManager.CurrentLanguage)
		{
			case DataManager.LANGUAGE.ENG:
				question = DataManager.EnglishQuestions[DataManager.CurrentQuestion];
				break;
			case DataManager.LANGUAGE.FRE:
				question = DataManager.FrenchQuestions[DataManager.CurrentQuestion];
				break;
			default:
				break;
		}
		QuestionText.text = $"{DataManager.CurrentQuestion + 1}. {question}";
	}

	public void UpdateFinalText()
	{
		var resultingText = "";
		switch (DataManager.CurrentLanguage)
		{
			case DataManager.LANGUAGE.ENG:
				resultingText = DataManager.EnglishFinalText;
				break;
			case DataManager.LANGUAGE.FRE:
				resultingText = DataManager.FrenchFinalText;
				break;
			default:
				break;
		}
		ResultText.text = resultingText;
	}

	public void MoveToScene(GameObject CurrentScene)
	{
		SelectedScene = CurrentScene;
		Selection.SetActive(false);
		Progression.SetActive(false);
		Results.SetActive(false);
		SelectedScene.SetActive(true);
	}

	public DataManager DataManager = null;
	public PlayerInput playerInput = null;

	public GameObject Selection = null;
	public GameObject Progression = null;
	public GameObject Results = null;

	public GameObject SelectedScene = null;

	public TextMeshProUGUI QuestionText = null;
	public TextMeshProUGUI ResultText = null;
}
