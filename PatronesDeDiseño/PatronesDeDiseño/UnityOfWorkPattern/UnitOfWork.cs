﻿using PatronesDeDiseño.Models;
using PatronesDeDiseño.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.UnityOfWorkPattern
{

    //Permite trabajar a la misma vez con los objetos de los modelos en una misma instancia. 1 conexión usada para trabajar con todos los objetos antes de cerrar
    //Unity of work mejora Repository Patter creando así el mismo contexto para dos modelos y por lo tanto si hay que actualizar o manipular 100 objetos da igual si son iguales o no se pueden trabajar en el mismo contexto.
    public class UnitOfWork : IUnitOfWork
    {

        private PatronesDeDiseñoContext _context;

        public IRepositoryGenerics<Beer> beers;
        public IRepositoryGenerics<Brand> brands;

        public UnitOfWork(PatronesDeDiseñoContext context)
        {
            _context = context;
        }


        public IRepositoryGenerics<Beer> Beers
        {
            get
            {
                return beers == null ? new Repository<Beer>(_context) : beers;
            }
        }

        public IRepositoryGenerics<Brand> Brands
        {
            get
            {
                return brands == null ? new Repository<Brand>(_context) : brands;
            } 
        }

    public void save()
        {
            _context.SaveChanges();
        }
    }
}
