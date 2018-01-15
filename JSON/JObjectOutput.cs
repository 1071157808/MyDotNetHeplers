

public void JObjectOutputTest()
{
    // strong typed instance
    var jsonObject = new JObject();
    // you can explicitly add values here using class interface
    jsonObject.Add("Entered", DateTime.Now);
    // or cast to dynamic to dynamically add/read properties    dynamic album = jsonObject;
    album.AlbumName = "Dirty Deeds Done Dirt Cheap";
    album.Artist = "AC/DC";
    album.YearReleased = 1976;
    album.Songs = new JArray() as dynamic;
    dynamic song = new JObject();
    song.SongName = "Dirty Deeds Done Dirt Cheap";
    song.SongLength = "4:11";
    album.Songs.Add(song);
    song = new JObject();
    song.SongName = "Love at First Feel";
    song.SongLength = "3:10";
    album.Songs.Add(song);
    Console.WriteLine(album.ToString());
}

