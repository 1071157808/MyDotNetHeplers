ArrayList al = newArrayList ();
al.AddRange (new [] { 1, 5, 9 });
List<int> list = al.Cast<int> ().ToList (); // cast是IE<T>的扩展方法，ToList()方法将IE<T>转换为List<T>集合