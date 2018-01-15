
public JObject PostAlbumJObject(JObject jAlbum)
{
    // dynamic input from inbound JSON
    dynamic album = jAlbum;
    // create a new JSON object to write out
    dynamic newAlbum = new JObject();
    // Create properties on the new instance
    // with values from the first
    newAlbum.AlbumName = album.AlbumName + " New";
    newAlbum.NewProperty = "something new";
    newAlbum.Songs = new JArray();
    foreach (dynamic song in album.Songs)
    {
        song.SongName = song.SongName + " New";
        newAlbum.Songs.Add(song);
    }
    return newAlbum;
}
