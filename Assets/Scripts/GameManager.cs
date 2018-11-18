using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameSettings Settings;

	void Awake(){
		//Check if instance already exists
		if (instance == null)
			
			//if not, set instance to this
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		Settings = new GameSettings(){
			AppLanguage = Language.Swedish,
			CategoryScoreThreshold = -1
		};
	}

	void Start () {
		//Load Categories
		//Load User Settings (language and such)
		// Settings = new GameSettings(){
		// 	AppLanguage = Language.English,
		// 	CategoryScoreThreshold = -1
		// };

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static List<Category> GetHardCodedCategories(){
		var cats = new List<Category>();
		
		cats.Add(new Category(Language.Swedish, "Djur"));
		cats.Add(new Category(Language.Swedish, "Natur"));
		cats.Add(new Category(Language.Swedish, "Havet"));
		cats.Add(new Category(Language.Swedish, "Grönsaker"));


		cats.Add(new Category(Language.English, "Animals"));
		cats.Add(new Category(Language.English, "Nature"));
		cats.Add(new Category(Language.English, "The Ocean"));
		cats.Add(new Category(Language.English, "Vegetables"));

		return cats;
	}
}
