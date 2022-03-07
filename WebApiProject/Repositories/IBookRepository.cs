using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public interface IBookRepository
    {
        Task<List<BooksModel>> GetAllBook();

        Task<BooksModel> GetBookById(int Id);

        Task<int> AddBook(BooksModel data);

        Task UpdateBook(int Id, BooksModel data);

        Task<int> DeleteBook(int Id);
    }
}
