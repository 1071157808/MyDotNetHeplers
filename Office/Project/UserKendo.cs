需要两个函数来给gantt图返回数据
  ScheduleGanntTaskModel model = new ScheduleGanntTaskModel();
  model.ID = task.UniqueID;
  model.ParentID = task.OutlineParent.ID;
  model.OrderID = task.ID;
  model.Title = task.Name;
  model.Start = task.Start.ToString();
  model.Summary = task.Summary.ToString();
  model.PercentComplete = task.PercentComplete.ToString();
  //这个指的是树形目录是否要展开,true为不展开，false为展开
  model.Expanded = true;
  GanntDependenciesModel model = new GanntDependenciesModel();
  model.ID = task.UniqueID;
  model.PredecessorID = task.Predecessors.ToString();
  model.SuccessorID = task.Successors.ToString();
  model.Type = task.Type.ToString();

http://docs.telerik.com/kendo-ui/api/javascript/data/ganttdependency

- 0 - Finish-Finish   FF
- 1 - Finish-Start     FS
- 2 - Start-Finish     SF
- 3 - Start-Start       SS




