//http://devmate.net/2017/11/entity-framework-contains-on-empty-collection/

//下面的这种做法不完善
var contactIds = new List<int>();
dbContext.Contacts.Where(x => contactIds.Contains(x.Id)).ToList();


//应该用这种做法，过滤掉空list，否则会浪费时间
if (contactIds != null && contactIds.Any())
{
      dbContext.Contacts.Where(x => contactIds.Contains(x.Id)).ToList();
}