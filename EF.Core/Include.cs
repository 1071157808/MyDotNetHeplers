viewModel.Instructors = await _context.Instructors
    .Include (i => i.OfficeAssignment)
    .Include (i => i.CourseAssignments)
    .ThenInclude (i => i.Course)
    .ThenInclude (i => i.Enrollments)
    .ThenInclude (i => i.Student)
    .Include (i => i.CourseAssignments)
    .ThenInclude (i => i.Course)
    .ThenInclude (i => i.Department)
    .AsNoTracking ()
    .OrderBy (i => i.LastName)
    .ToListAsync ();