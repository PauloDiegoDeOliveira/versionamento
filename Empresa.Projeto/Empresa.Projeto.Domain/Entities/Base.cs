﻿namespace Empresa.Projeto.Domain
{
    public abstract class Base
    {
        public long Id { get; private set; }

        protected Base() { }
        protected Base(long id) 
        {
            Id = id;
        }
    }
}