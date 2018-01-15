EF的搜索应该是这样使用
Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()).
