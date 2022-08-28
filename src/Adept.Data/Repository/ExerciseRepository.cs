﻿using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        private AdeptDatabaseContext _context;

        public ExerciseRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory): base(DbContextFactory)
        {
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return _context.Exercises.AsNoTracking();
        }

        public async Task<int> GetExercisesCountAsync()
        {
            var count = 0;
            try
            {
                count = await _context.Exercises.CountAsync();
            }
            catch (NullReferenceException ex)
            {
            }
            return count;
            //return await _context.Exercises.CountAsync();
        }
    }
}
