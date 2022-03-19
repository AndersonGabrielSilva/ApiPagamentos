using Pagamento.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Entities
{
    public abstract class Entity 
    {
        protected Entity()
        {
            DtaCreate = DateTime.Now;
        }

        public virtual int Id { get; set; }

        public virtual DateTime DtaCreate { get;}
        public virtual DateTime DtaUpdate { get; set; }
        public virtual bool IsActive { get; set; }
        
        public virtual string NoteUpdate { get; set; }
        
        /// <summary>
        /// Registra a alteração
        /// </summary>
        /// <param name="noteUpdate">Nota de Atualização</param>
        public virtual void RegistraAlteracao(string noteUpdate = "")
        {
            this.DtaUpdate = DateTime.Now;
            this.NoteUpdate = noteUpdate;
        }

        public void Desativar(string noteUpdate = "")
        {
            this.IsActive = false;
            this.NoteUpdate = noteUpdate;
        }

        public void Ativar(string noteUpdate = "")
        {
            this.IsActive = true;
            this.NoteUpdate = noteUpdate;
        }
    }
}
