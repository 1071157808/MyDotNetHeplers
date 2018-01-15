int multiplier = 12;
ViewData["RowsAffected"] =
    await _context.Database.ExecuteSqlCommandAsync (
        "UPDATE Course SET Credits = Credits * {0}",
        parameters : multiplier);