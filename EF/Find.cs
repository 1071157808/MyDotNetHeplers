PMapToStoredProceduresublic TouristAttraction GetTouristAttraction(int id)
{
    TouristAttraction touristattraction = db.TouristAttractions.Find(id);
}

var person = context.People.Find(1);
