using System;
using System.Threading.Tasks;
using System.Collections.Generic;


public interface ICategoryRepository{
	Task<Category> InsertOrMergeAsync(Category entity);
	Task<Category> GetAsync(Language language, string rowKey);
	Task DeleteCategoryAsync(Category deleteEntity);
	Task<IEnumerable<Category>> GetAllByLanguage(Language language);
}