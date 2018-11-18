using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;

public class CategoryLabelHandler : MonoBehaviour {

    public Text Label;
    public Button RefreshButton;
    public IEnumerable<Category> Categories;
    
    public GameSettings Settings;

    public async void Start(){

        Categories = await CategoryRepository.instance.GetAllByLanguage(GameManager.instance.Settings.AppLanguage);

        //Categories = GameManager.GetHardCodedCategories();
        RefreshButton.GetComponentInChildren<Text>().text = I18n.instance.GetLocalizedValue("refresh_key_caption");
        RefreshButton.onClick.AddListener(SetRandomCategory);
        
        SetRandomCategory();

    }

    public void SetRandomCategory(){
        var cats = Categories.ToList();
        var currentCategory = cats[UnityEngine.Random.Range(0, cats.Count)];
        Label.text = currentCategory.Value;
    }

}