using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Data.Repositories
{
   public class HeaderRepository:BaseRepository<Header>,IHeaderRepository
    {
        private readonly GaripSozlukDbContext _context;
        public HeaderRepository(GaripSozlukDbContext context):base(context)
        {
            _context = context;
        }
        public IQueryable<Header> GetAllByCategoryId(int id)
        {           
            return GetAll().Where(x => x.CategoryId==id);
        }

    }
}
