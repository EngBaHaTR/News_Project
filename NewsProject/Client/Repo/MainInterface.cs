﻿namespace NewsProject.Client.Repo
{
    public interface MainInterface<T> where T : class
    {
        Task<List<T>> GetAllAsync(string e);
        Task AddRowAsync(T item,string url);
    }
}
