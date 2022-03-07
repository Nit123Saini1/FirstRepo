using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Data;
using WebApiProject.Models;
using WebApiProject.Tables;

namespace WebApiProject.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly BookDbContext _db;
        private readonly IMapper _mapper;
        public BookRepository(BookDbContext bookDbContext,IMapper mapper)
        {
            _db = bookDbContext;
            _mapper = mapper;
        }

        public async Task<List<BooksModel>> GetAllBook()
        {
            var result = new List<BooksModel>();
            foreach (var data in _db.tblBooks.ToList())
            {
                var item = new BooksModel()
                {
                    Id=data.Id,
                    Name=data.Name,
                    Description=data.Description
                };
                result.Add(item);
            }
            return result;
        }

        public async Task<BooksModel> GetBookById(int Id)
        {
            //Without AutoMapper
            //var data = _db.tblBooks.Where(x=>x.Id==Id).FirstOrDefault();
            //var item = new BooksModel();
            //if (data != null)
            //{
            //    item = new BooksModel()
            //    {
            //        Id = data.Id,
            //        Name = data.Name,
            //        Description = data.Description
            //    };
            //}

            //return item;


            //With AutoMapper

            var reult = await _db.tblBooks.FindAsync(Id);

            return _mapper.Map<BooksModel>(reult);
        }

        public async Task<int> AddBook(BooksModel data)
        {
            var item = new tblBook()
            {
                
                Name = data.Name,
                Description = data.Description
            };
            _db.tblBooks.Add(item);
            await _db.SaveChangesAsync();
            return item.Id;
        }

        public async Task UpdateBook(int Id, BooksModel data)
        {
            //this method also valid
            //var Data = _db.tblBooks.Where(x => x.Id == Id).FirstOrDefault();

            //if(Data != null)
            //{
            //    Data.Name = data.Name;
            //    Data.Description = data.Description;

            //    _db.tblBooks.Update(Data);
            //    await _db.SaveChangesAsync();
            //}


            var Data = new tblBook()
            {
                Id= Id,
                Name = data.Name,
                Description = data.Description
            };
            

            _db.tblBooks.Update(Data);
            await _db.SaveChangesAsync();

        }

        public async Task<int> DeleteBook(int Id)
        {
            
            var Data = new tblBook()
            {
                Id = Id,
                
            };


            _db.tblBooks.Remove(Data);
            await _db.SaveChangesAsync();

            return Id;
        }
    }
}
