public async Task<ActionResult> About () {
    List<EnrollmentDateGroup> groups = new List<EnrollmentDateGroup> ();
    var conn = _context.Database.GetDbConnection ();
    try {
        await conn.OpenAsync ();
        using (var command = conn.CreateCommand ()) {
            string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount " +
                "FROM Person " +
                "WHERE Discriminator = 'Student' " +
                "GROUP BY EnrollmentDate";
            command.CommandText = query;
            DbDataReader reader = await command.ExecuteReaderAsync ();
            if (reader.HasRows) {
                while (await reader.ReadAsync ()) {
                    var row = new EnrollmentDateGroup { EnrollmentDate = reader.GetDateTime (0), StudentCount = reader.GetInt32 (1) };
                    groups.Add (row);
                }
            }
            reader.Dispose ();
        }
    } finally {
        conn.Close ();
    }
    return View (groups);
}