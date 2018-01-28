privateNewEntity GetLastApproveVersionByItem (SPListItem item) {
    NewEntity result = null;
    if (item == null) returnresult;
    if (item.Level == SPFileLevel.Published) {
        result = this.ConvertToEntity (item);
    }
    elseif (item.Versions != null && item.Versions.Count > 0) {
        foreach (SPListItemVersion itemVersioninitem.Versions) {
            if (itemVersion.Level == SPFileLevel.Published) {
                result = this.ConvertToEntity (itemVersion);
                break;
            }
        }
    }
    returnresult;
}