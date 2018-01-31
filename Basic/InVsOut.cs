//--------------in----demo------------

ListIn:IList<in T>
ListIn<Object> lobject = new ListIn<Object>() { "0", "1", "2" };
ListIn<int> lint = new ListIn<int>;
lint = lobject; 


//------------out----demo--------------

ListOut:IList<out T>
ListOut<int> lint= new ListOut<int>() { 0, 1, 2 };
ListOut<Object> lobject = new ListOut<Object>();
lobject=lint; 
