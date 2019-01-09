﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EF_Core_Demo.Repositories
{
    public class Repository<TEntity>
        : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _entities;

        protected DbContext Context;

        public Repository( DbContext context )
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public void Add( TEntity entity )
        {
            _entities.Add( entity );
        }

        public void AddRange( IEnumerable<TEntity> entities )
        {
            _entities.AddRange( entities );
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public TEntity GetById( int id )
        {
            return _entities.Find( id );
        }

        public void Remove( TEntity entity )
        {
            _entities.Remove( entity );
        }

        public void RemoveRange( IEnumerable<TEntity> entities )
        {
            _entities.RemoveRange( entities );
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where( predicate ).ToList();
        }
    }
}
