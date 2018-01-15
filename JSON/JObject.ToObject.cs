
JArray albums = JArray.Parse(jsonString) as JArray;
// pick out one album
JObject jalbum = albums[0] as JObject;
// Copy to a static Album instance
Album album = jalbum.ToObject<Album>();