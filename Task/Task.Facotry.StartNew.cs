Task.Facotry.StartNew比Task.Run强大
为什么在进行动态并行开发时，一定要用Task.Facotry.StartNew来代替Task.Run？两者的区别是什么？
因为根据默认配置，Task.Run返回的Task对象适合被异步调用，
task.run不支持动态并行代码中普遍使用的高级概念，如父子任务


