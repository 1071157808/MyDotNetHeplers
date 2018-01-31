BitArray是一个都bool值组成的、大小可动态变化的集合。
它比bool[]或List<bool>有更多的内存效率，这是因为每个元素都值占用一bit的内存空间，
而bool类型则占用1byte空间（1byte=8bit）。通过索引器可以读取和更改BitArray元素的值



