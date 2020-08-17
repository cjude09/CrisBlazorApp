using CrisBlazorApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrisBlazorApp.Business.Services.Interfaces
{
    public interface IBlazorService
    {
        void ChangeConnection();
        Task<List<Dictionary<string, object>>> Retrieve(string keyword);
    }
}
