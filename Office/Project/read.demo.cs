引入这个Microsoft.Office.Interop.MSProject.dll
设置这个dll的互操作类型为False





   #region 存入数据库--Dhtmlx
        [Description("导入project文件到数据库-Dxhtml模式")]
        [AllowAnonymous]
        public ActionResult ImportScheduleEntityToDhtmlxDb(int scheduleEntityId=1)
        {
            #region 注释代码
            //方法太耗时，更改为后台队列处理
            //var jsonData = "";
            //try
            //{

            //    var scheduleEntity = modelDb.ScheduleEntities.FirstOrDefault(a => a.ScheduleEntityId == scheduleEntityId);
            //    var localFilePath = Urlconvertorlocal(scheduleEntity.FilePath);
            //    ApplicationClass projectApp = new ApplicationClass();
            //    Thread.Sleep(3000);
            //    projectApp.FileOpen(localFilePath, true, Missing.Value, Missing.Value, Missing.Value,
            //    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
            //    PjPoolOpen.pjPoolReadOnly, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //    Project proj = projectApp.ActiveProject;

            //    foreach (Microsoft.Office.Interop.MSProject.Task task in proj.Tasks)
            //    {
            //        if (task == null) continue;
            //        DhtmlDanttTaskEntity dhtmlDanttTaskEntity = new DhtmlDanttTaskEntity();
            //        dhtmlDanttTaskEntity.TaskId = task.UniqueID;
            //        dhtmlDanttTaskEntity.ParentId = task.OutlineParent.UniqueID;
            //        //把Duration由分钟转换为小时
            //        dhtmlDanttTaskEntity.Duration = Convert.ToInt32(task.Duration) / (60 * 8);
            //        dhtmlDanttTaskEntity.Priority = task.OutlineLevel;
            //        dhtmlDanttTaskEntity.Text = task.Name;
            //        dhtmlDanttTaskEntity.users = task.ResourceNames;
            //        List<string> petNameList = new List<string>();
            //        if (!string.IsNullOrEmpty(dhtmlDanttTaskEntity.users))
            //        {
            //            var userNames = dhtmlDanttTaskEntity.users.Split(',').ToArray();
            //            foreach (var userName in userNames)
            //            {
            //                var userEntity = _userManager.FindByName(userName);
            //                var petName = userEntity.Claims.FirstOrDefault(a => a.ClaimType == "PetName") == null ?
            //                            "" : userEntity.Claims.FirstOrDefault(a => a.ClaimType == "PetName").ClaimValue;
            //                if (!string.IsNullOrEmpty(petName))
            //                {
            //                    petNameList.Add(petName);
            //                }
            //            }
            //        }
            //        dhtmlDanttTaskEntity.PetNames = string.Join(",", petNameList);
            //        dhtmlDanttTaskEntity.Progress = Convert.ToDouble(task.PercentComplete);
            //        if (task.Start != null)
            //        {
            //            //dhtmlDanttTaskEntity.StartDate = Convert.ToDateTime(task.Start).ToString("dd-MM-yyyy");
            //            dhtmlDanttTaskEntity.StartDate = Convert.ToDateTime(task.Start);
            //        }
            //        scheduleEntity.DhtmlDanttTaskEntities.Add(dhtmlDanttTaskEntity);
            //        if (task.PredecessorTasks.Count > 0)
            //        {
            //            var predecessorString = task.UniqueIDPredecessors;
            //            if (predecessorString.Contains(','))
            //            {
            //                var predecessorStringArray = predecessorString.Split(',');
            //                foreach (string predecessorStringTemp in predecessorStringArray)
            //                {
            //                    var model2 = GetDhtmlGanttLinkEntity(predecessorStringTemp, task.ID);
            //                    scheduleEntity.DhtmlGanttLinkEntities.Add(model2);
            //                }
            //            }
            //            else
            //            {
            //                var model3 = GetDhtmlGanttLinkEntity(predecessorString, task.ID);
            //                scheduleEntity.DhtmlGanttLinkEntities.Add(model3);
            //            }
            //        }
            //    }
            //    projectApp.FileCloseAllEx(PjSaveType.pjDoNotSave);
            //    var i = modelDb.SaveChanges();
            //    if (i > 0)
            //    {
            //        jsonData = JsonConvert.SerializeObject(new { result = true });
            //    }
            //    else
            //    {
            //        throw new System.Exception("操作失败");
            //    }

            //}
            //catch (System.Exception ex)
            //{
            //    jsonData = JsonConvert.SerializeObject(new { result = false, error = ex.Message });
            //}
            //return Content(jsonData);
            #endregion
            var jsonData = "";
            try
            {
                BackgroundJob.Enqueue(() => ImportScheduleEntityToDbJob(scheduleEntityId));
                //ImportScheduleEntityToDbJob(scheduleEntityId);
                jsonData = JsonConvert.SerializeObject(new { result = true });
            }
            catch (System.Exception ex)
            {

                jsonData = JsonConvert.SerializeObject(new { result = false, error = ex.Message });
            }
            return Content(jsonData);

        }
        [DisplayName("ImportScheduleEntityToDbJob")]
        public void ImportScheduleEntityToDbJob(int scheduleEntityId)
        {
            using(var modelNewDb = new ModelDb())
            {
            var scheduleEntity = modelNewDb.ScheduleEntities.FirstOrDefault(a => a.ScheduleEntityId == scheduleEntityId);
            if (scheduleEntity != null)
            {
                //var localFilePath = Urlconvertorlocal(scheduleEntity.FilePath);
                var localFilePath = scheduleEntity.FileRealPath;
                ApplicationClass projectApp = new ApplicationClass();
                Thread.Sleep(3000);
                projectApp.FileOpen(localFilePath, true, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                PjPoolOpen.pjPoolReadOnly, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                Project proj = projectApp.ActiveProject;

                foreach (Microsoft.Office.Interop.MSProject.Task task in proj.Tasks)
                {
                    if (task == null) continue;
                    DhtmlDanttTaskEntity dhtmlDanttTaskEntity = new DhtmlDanttTaskEntity();
                    dhtmlDanttTaskEntity.TaskId = task.UniqueID;
                    dhtmlDanttTaskEntity.ParentId = task.OutlineParent.UniqueID;
                    //把Duration由分钟转换为小时
                    dhtmlDanttTaskEntity.Duration = Convert.ToInt32(task.Duration) / (60 * 8);
                    dhtmlDanttTaskEntity.Priority = task.OutlineLevel;
                    dhtmlDanttTaskEntity.Text = task.Name;
                    dhtmlDanttTaskEntity.users = task.ResourceNames;
                    List<string> petNameList = new List<string>();
                    if (!string.IsNullOrEmpty(dhtmlDanttTaskEntity.users))
                    {
                        var userNames = dhtmlDanttTaskEntity.users.Split(',').ToArray();
                        foreach (var userName in userNames)
                        {
                            var userEntity = _userManager.FindByName(userName);
                            var petName = userEntity.Claims.FirstOrDefault(a => a.ClaimType == "PetName") == null ?
                                        "" : userEntity.Claims.FirstOrDefault(a => a.ClaimType == "PetName").ClaimValue;
                            if (!string.IsNullOrEmpty(petName))
                            {
                                petNameList.Add(petName);
                            }
                        }
                    }
                    dhtmlDanttTaskEntity.PetNames = string.Join(",", petNameList);
                    dhtmlDanttTaskEntity.Progress = Convert.ToDouble(task.PercentComplete);
                    if (task.Start != null)
                    {
                        //dhtmlDanttTaskEntity.StartDate = Convert.ToDateTime(task.Start).ToString("dd-MM-yyyy");
                        dhtmlDanttTaskEntity.StartDate = Convert.ToDateTime(task.Start);
                    }
                    scheduleEntity.DhtmlDanttTaskEntities.Add(dhtmlDanttTaskEntity);
                    if (task.PredecessorTasks.Count > 0)
                    {
                        var predecessorString = task.UniqueIDPredecessors;
                        if (predecessorString.Contains(','))
                        {
                            var predecessorStringArray = predecessorString.Split(',');
                            foreach (string predecessorStringTemp in predecessorStringArray)
                            {
                                var model2 = GetDhtmlGanttLinkEntity(predecessorStringTemp, task.ID);
                                scheduleEntity.DhtmlGanttLinkEntities.Add(model2);
                            }
                        }
                        else
                        {
                            var model3 = GetDhtmlGanttLinkEntity(predecessorString, task.ID);
                            scheduleEntity.DhtmlGanttLinkEntities.Add(model3);
                        }
                    }
                }
                projectApp.FileCloseAllEx(PjSaveType.pjDoNotSave);
                var i = modelNewDb.SaveChanges();
            }
            }
        }

        public DhtmlGanttLinkEntity GetDhtmlGanttLinkEntity(string predecessorString, int taskId)
        {
            DhtmlGanttLinkEntity temp = new DhtmlGanttLinkEntity();
            temp.SourceTaskId = taskId;
            if (predecessorString.Contains("FF"))
            {
                var idTemp = predecessorString.Substring(0, predecessorString.IndexOf("FF"));
                temp.TargetTaskId = Convert.ToInt32(idTemp);
                temp.Type = "0";
            }
            else if (predecessorString.Contains("SF"))
            {
                var idTemp = predecessorString.Substring(0, predecessorString.IndexOf("SF"));
                temp.TargetTaskId = Convert.ToInt32(idTemp);
                temp.Type = "2";
            }
            else if (predecessorString.Contains("SS"))
            {
                var idTemp = predecessorString.Substring(0, predecessorString.IndexOf("SS"));
                temp.TargetTaskId = Convert.ToInt32(idTemp);
                temp.Type = "3";
            }
            else if (predecessorString.Contains("FS"))
            {
                var idTemp = predecessorString.Substring(0, predecessorString.IndexOf("FS"));
                temp.TargetTaskId = Convert.ToInt32(idTemp);
                temp.Type = "1";
            }
            else
            {
                temp.TargetTaskId = Convert.ToInt32(predecessorString);
                temp.Type = "1";
            }
            return temp;
        }
        #endregion