

public void JsonArrayParsingTest()
{
    var jsonString = @"[
{
""Id"": ""b3ec4e5c"",
""AlbumName"": ""Dirty Deeds Done Dirt Cheap"",
""Artist"": ""AC/DC"",
""YearReleased"": 1976,
""Entered"": ""2012-03-16T00:13:12.2810521-10:00"",
""AlbumImageUrl"": ""http://ecx.images-amazon.com/images/I/61kTaH-uZBL._AA115_.jpg"";,
""AmazonUrl"": ""http://www.amazon.com/gp/product/…ASIN=B00008BXJ4"";,
""Songs"": [
    {
    ""AlbumId"": ""b3ec4e5c"",
    ""SongName"": ""Dirty Deeds Done Dirt Cheap"",
    ""SongLength"": ""4:11""
    },
    {
    ""AlbumId"": ""b3ec4e5c"",
    ""SongName"": ""Love at First Feel"",
    ""SongLength"": ""3:10""
    },
    {
    ""AlbumId"": ""b3ec4e5c"",
    ""SongName"": ""Big Balls"",
    ""SongLength"": ""2:38""
    }
]
},
{
""Id"": ""7b919432"",
""AlbumName"": ""End of the Silence"",
""Artist"": ""Henry Rollins Band"",
""YearReleased"": 1992,
""Entered"": ""2012-03-16T00:13:12.2800521-10:00"",
""AlbumImageUrl"": ""http://ecx.images-amazon.com/images/I/51FO3rb1tuL._SL160_AA160_.jpg"";,
""AmazonUrl"": ""http://www.amazon.com/End-Silence-Rollins-Band/dp/B0000040OX/ref=sr_1_5?ie=UTF8&qid=1302232195&sr=8-5"";,
""Songs"": [
    {
    ""AlbumId"": ""7b919432"",
    ""SongName"": ""Low Self Opinion"",
    ""SongLength"": ""5:24""
    },
    {
    ""AlbumId"": ""7b919432"",
    ""SongName"": ""Grip"",
    ""SongLength"": ""4:51""
    }
]
}
]";
    JArray jsonVal = JArray.Parse(jsonString) as JArray;
    dynamic albums = jsonVal;
    foreach (dynamic album in albums)
    {
        Console.WriteLine(album.AlbumName + " (" + album.YearReleased.ToString() + ")");
        foreach (dynamic song in album.Songs)
        {
            Console.WriteLine("\t" + song.SongName);
        }
    }
    Console.WriteLine(albums[0].AlbumName);
    Console.WriteLine(albums[0].Songs[1].SongName);
}

