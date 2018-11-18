using UnityEngine;
using System.Collections;

    public class Loader : MonoBehaviour 
    {
        public GameObject gameManager;          //GameManager prefab to instantiate.
        public GameObject i18n;          //I18n prefab to instantiate.
        public CategoryRepository categoryRepo;
                
        void Awake ()
        {
            //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
            if (GameManager.instance == null)
                
                //Instantiate gameManager prefab
                Instantiate(gameManager);            //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
            if (I18n.instance == null)
                
                //Instantiate gameManager prefab
                Instantiate(i18n);
            if (CategoryRepository.instance == null)
                
                //Instantiate gameManager prefab
                Instantiate(categoryRepo);
        }
    }