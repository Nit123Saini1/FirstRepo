using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;
using WebApiProject.Repositories;

namespace WebApiProject.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllBooks()
        {
            var result =await _bookRepository.GetAllBook();
            if(result.Count == 0)
            {
                return NotFound();
            }
            return Ok(_bookRepository.GetAllBook());
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetBookById([FromRoute]int Id)
        {
            var result = await _bookRepository.GetBookById(Id);
            if (result.Name == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BooksModel model)
        {
            var result = await _bookRepository.AddBook(model);
            if (result == 0)
            {
                return NotFound();
            }
            return Created("AddBook", result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id,[FromBody] BooksModel model)
        {
            await _bookRepository.UpdateBook(id,model);
            
            return Ok();
        }

        [HttpDelete("{id:int}")]
        //[Authorize]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBook(id);

            return Ok();
        }
    }
}
