﻿using GoodBooks.Data;
using GoodBooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        private readonly GoodBooksDbContext _db;

        public BookService(GoodBooksDbContext db)
        {
            this._db = db;
        }
        public void AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var bookToDeleted = _db.Books.Find(bookId);
            if (bookToDeleted != null)
            {
                _db.Remove(bookToDeleted);
            }

            throw new InvalidOperationException("Can't delete book that doesn't exist");
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
            return _db.Books.Find(bookId);
        }
    }
}
