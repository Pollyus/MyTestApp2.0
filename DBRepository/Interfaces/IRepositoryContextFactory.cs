﻿namespace DBRepository.Interfaces
{
    public interface IRepositoryContextFactory
    {
        RepositoryDbContext CreateDbContext(string connectionString);
    }
}