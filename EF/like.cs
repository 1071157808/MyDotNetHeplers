ef中的相等应该是用like来做验证的
经过测试，在EF中使用string的相等验证，不管是==，还是equals都是忽略大小写的

其实==和equals是相等验证，只要在ef中lambda表达式的外头就可以正常使用

说明EF中可能使用like来做验证的
