        catch (DbUpdateConcurrencyException ex) {
            EntityEntry entityEntry = ex.Entries[0];
            //kept in DbChangeTracker
            PropertyValues originalVaules = entityEntry.OriginalValues;
            PropertyValues currentVaules = entityEntry.CurrentValues;
            var properties = entityEntry.Properties;
            PropertyValues databaseValues = entityEntry.GetDatabaseValues ();
        }

        //在config中配置异常
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder
                .UseSqlServer (@"Server=(localdb)\mssqllocaldb;Database=EFQuerying;Trusted_Connection=True;")
                .ConfigureWarnings (warnings => warnings.Throw (CoreEventId.IncludeIgnoredWarning))
        }