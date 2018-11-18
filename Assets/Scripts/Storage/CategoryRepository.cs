using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class CategoryRepository : MonoBehaviour, ICategoryRepository
{

	public static CategoryRepository instance;

	void Awake()
	{
		if (instance == null)
			
			//if not, set instance to this
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
	
	public async Task<Category> InsertOrMergeAsync(Category entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}

		throw new NotImplementedException();
	}

    public Task<Category> GetAsync(Language language, string rowKey)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(Category deleteEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAllByLanguage(Language language)
    {
		var w = StartCoroutine(GetAll());
		Debug.Log(w);
//		return all.Where(x => x.Language == language);
		return new List<Category>(){
			new Category(Language.Swedish, "Ett värde")
		};
    }
    public System.Collections.IEnumerator GetAll()
    {
		var request = UnityWebRequest.Get("https://tillmansspel.azurewebsites.net/api/Category/getallobjectsbylanguage?languageString=swedish");
		
		yield return request.SendWebRequest();
		
		if(request.isNetworkError || request.isHttpError){
			Debug.Log("Error: ");
			Debug.Log(request.error);
		}
		else{
            var result = request.downloadHandler.text;
			Debug.Log(result);
		}
    }
}