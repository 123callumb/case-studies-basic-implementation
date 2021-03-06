﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.GenericRepository
{
    /// <summary>
    /// This is a generic repository that subtracts the need for entity repositories.
    /// </summary>
    public interface IGenericRepo
    {
        /// <summary>
        /// Add a row to the database.
        /// </summary>
        /// <typeparam name="Entity">Must be of type that belongs the entites generated by entity frameworks scaffold/</typeparam>
        /// <returns>An integer for how many rows in the db have been affected.</returns>
        Task<int> Add<Entity>(Entity entity) where Entity : class;
        /// <summary>
        /// Add a multiple rows to the database.
        /// </summary>
        /// <typeparam name="Entity">Must be of type that belongs the entites generated by entity frameworks scaffold/</typeparam>
        /// <returns>An integer for how many rows in the db have been affected.</returns>
        Task<int> AddRange<Entity>(List<Entity> entity) where Entity : class;
        /// <summary>
        /// Remove rows from the database.
        /// </summary>
        /// <typeparam name="Entity">Must be of type that belongs the entites generated by entity frameworks scaffold/</typeparam>
        /// <returns>An integer for how many rows in the db have been affected.</returns>
        Task<int> RemoveRange<Entity>(List<Entity> entity) where Entity : class;
        /// <summary>
        /// Remove a row from the database.
        /// </summary>
        /// <typeparam name="Entity">Must be of type that belongs the entites generated by entity frameworks scaffold/</typeparam>
        /// <returns>An integer for how many rows in the db have been affected.</returns>
        Task<int> Remove<Entity>(Entity entity) where Entity : class;
        /// <summary>
        /// Used after editing dbset entities.
        /// </summary>
        /// <returns>An integer for how many rows in the db have been affected.</returns>
        Task<int> SaveChanges();
    }
}
