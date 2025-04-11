using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		SelectedProfiles = new Profile[3];
		EnglishQuestions = new string[23];
		FrenchQuestions = new string[23];
		SelectedProfilesAnswers = new bool[23 * 3];
		// TODO: ADD THE QUESTIONS
		// TODO: IMPLEMENT OTHER LANGUAGES
		FillQuestionsEnglish();
		FillQuestionsFrench();

		// Randomises the profiles to start the run
		RandomizeValues();
	}

	private void FillQuestionsEnglish()
	{
		EnglishQuestions[0] = "You have never had serious financial difficulties";
		EnglishQuestions[1] = "You have decent accommodation with phone and television";
		EnglishQuestions[2] = "You believe that your language, religion and culture are respected in the society in wich you live";
		EnglishQuestions[3] = "You feel that your opinions on political and social issues and your point of view are listened to";
		EnglishQuestions[4] = "Other people consult you on different issues";
		EnglishQuestions[5] = "You are not afraid of being arrested by the police";
		EnglishQuestions[6] = "You know who to turn to for advice and help when needed";
		EnglishQuestions[7] = "You have never been discriminated against because of your origin";
		EnglishQuestions[8] = "You benefit from social and medical and medical protection adapted to your needs";
		EnglishQuestions[9] = "You can go on vacation once a year";
		EnglishQuestions[10] = "You can have friends over for dinner";
		EnglishQuestions[11] = "You have an interesting life and are optimistic about your future";
		EnglishQuestions[12] = "You think you can study and practice the profession of your choice";
		EnglishQuestions[13] = "You are not afraid of being harassed or attacked in the streets or by the media";
		EnglishQuestions[14] = "You can vote in locals and national elections";
		EnglishQuestions[15] = "You can celebrate the most important religious holidays with your parents and close friends";
		EnglishQuestions[16] = "You can participate in an international seminar abroad";
		EnglishQuestions[17] = "You can go to the cinema or the theatre at least once a week";
		EnglishQuestions[18] = "You are not worried about your children’s future";
		EnglishQuestions[19] = "You can buy yourself new clothes at least every three months";
		EnglishQuestions[20] = "You can fall in love with the person of your choice";
		EnglishQuestions[21] = "You feel that your skills are valued and respected in the society you live in";
		EnglishQuestions[22] = "You can use the internet and benefit from its advantage";
	}

	private void FillQuestionsFrench()
	{
		FrenchQuestions[0] = "Vous n'avez jamais rencontré de difficultés financières graves";
		FrenchQuestions[1] = "Vous disposez d'un logement décent avec téléphone et télévision";
		FrenchQuestions[2] = "Vous estimez que votre langue, votre religion et votre culture sont respectées dans la société dans laquelle vous vivez";
		FrenchQuestions[3] = "Vous sentez que vos opinions sur les questions politiques et sociales et votre point de vue sont pris en compte";
		FrenchQuestions[4] = "D'autres personnes vous consultent sur différents sujets";
		FrenchQuestions[5] = "Vous n'avez pas peur d'être arrêté par la police";
		FrenchQuestions[6] = "Vous savez vers qui vous tourner pour obtenir des conseils et de l'aide en cas de besoin";
		FrenchQuestions[7] = "Vous n'avez jamais été victime de discrimination en raison de votre origine";
		FrenchQuestions[8] = "Vous bénéficiez d'une protection sociale et médicale adaptée à vos besoins";
		FrenchQuestions[9] = "Vous pouvez partir en vacances une fois par an";
		FrenchQuestions[10] = "Vous pouvez recevoir des amis à dîner";
		FrenchQuestions[11] = "Vous avez une vie intéressante et êtes optimiste quant à votre avenir";
		FrenchQuestions[12] = "Vous pensez pouvoir étudier et exercer la profession de votre choix";
		FrenchQuestions[13] = "Vous n'avez pas peur d'être harcelé ou agressé dans la rue ou par les médias";
		FrenchQuestions[14] = "Vous pouvez voter aux élections locales et nationales";
		FrenchQuestions[15] = "Vous pouvez célébrer les fêtes religieuses les plus importantes avec vos parents et vos amis proches";
		FrenchQuestions[16] = "Vous pouvez participer à un séminaire international à l'étranger";
		FrenchQuestions[17] = "Vous pouvez aller au cinéma ou au théâtre au moins une fois par semaine";
		FrenchQuestions[18] = "Vous n'êtes pas inquiet pour l'avenir de vos enfants";
		FrenchQuestions[19] = "Vous pouvez vous acheter de nouveaux vêtements au moins tous les trois mois";
		FrenchQuestions[20] = "Vous pouvez tomber amoureux de la personne de votre choix";
		FrenchQuestions[21] = "Vous sentez que vos compétences sont valorisées et respectées dans la société où vous vivez";
		FrenchQuestions[22] = "Vous pouvez utiliser Internet et profiter de ses avantages";
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void RandomizeValues()
	{
		if (Profiles.Length == 0)
			return;

		Profile[] GroupOne = Array.FindAll(Profiles, x => x.Group == 1);
		Profile[] GroupTwo = Array.FindAll(Profiles, x => x.Group == 2);
		Profile[] GroupThree = Array.FindAll(Profiles, x => x.Group == 3);

		int RandomSelectionOne = UnityEngine.Random.Range(0, GroupOne.Length);
		int RandomSelectionTwo = UnityEngine.Random.Range(0, GroupTwo.Length);
		int RandomSelectionThree = UnityEngine.Random.Range(0, GroupThree.Length);

		SelectedProfiles[0] = GroupOne[RandomSelectionOne];
		SelectedProfiles[1] = GroupTwo[RandomSelectionOne];
		SelectedProfiles[2] = GroupThree[RandomSelectionThree];

		UpdateProfile();
	}

	public void UpdateProfile()
	{
		for (int i = 0; i < profileHolders.Length; i++)
		{
			ProfileHolder profileHolder = profileHolders[i];
			profileHolder.UpdateProfile(SelectedProfiles[i], CurrentLanguage);
		}
	}

	//void AddAnswers(bool answerOne, bool answerTwo, bool answerThree)
	//{
	//	if (SelectedProfiles.Length == 0)
	//		return;

	//	foreach (var Profile in SelectedProfiles)
	//	{
	//		bool Answer = false;
	//		switch (Profile.Group)
	//		{
	//			case 1:
	//				Answer = answerOne;
	//				break;
	//			case 2:
	//				Answer = answerTwo;
	//				break;
	//			case 3:
	//				Answer = answerThree;
	//				break;
	//			default:
	//				break;
	//		}
	//		var number = (Profile.Group - 1) * MAX_QUESTIONS + CurrentQuestion;
	//		Debug.Log(number);
	//		SelectedProfilesAnswers[number] = Answer;
	//	}
	//}

	public void ProfileOneAnswerUpdated(bool answer)
	{
		var arrayIndex = (SelectedProfiles[0].Group - 1) * MAX_QUESTIONS + CurrentQuestion;
		Debug.Log($"Q{CurrentQuestion} - P1 - {arrayIndex}");
		SelectedProfilesAnswers[arrayIndex] = answer;
	}

	public void ProfileTwoAnswerUpdated(bool answer)
	{
		var arrayIndex = (SelectedProfiles[1].Group - 1) * MAX_QUESTIONS + CurrentQuestion;
		Debug.Log($"Q{CurrentQuestion} - P2 - {arrayIndex}");
		SelectedProfilesAnswers[arrayIndex] = answer;
	}

	public void ProfileThreeAnswerUpdated(bool answer)
	{
		var arrayIndex = (SelectedProfiles[2].Group - 1) * MAX_QUESTIONS + CurrentQuestion;
		Debug.Log($"Q{CurrentQuestion} - P3 - {arrayIndex}");
		SelectedProfilesAnswers[arrayIndex] = answer;
	}

	public bool[] SelectedProfilesAnswers = null;
	public Profile[] SelectedProfiles = null;
	public Profile[] Profiles = null;
	public int MAX_QUESTIONS = 23;
	public int CurrentQuestion = 0;
	public string[] EnglishQuestions = null;
	public string[] FrenchQuestions = null;
	public enum LANGUAGE
	{
		ENG,
		FRE
	}
	public LANGUAGE CurrentLanguage = LANGUAGE.ENG;

	public ProfileHolder[] profileHolders = null;

	public string EnglishFinalText = "Not everyone has an easy life.";
	public string FrenchFinalText = "Tout le monde n'a pas une vie facile.";
}
