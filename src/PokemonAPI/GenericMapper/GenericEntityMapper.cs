using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMapper
{
    public class GenericEntityMapper<Model, Entity> where Model : class
                                                    where Entity : class
    {
        private readonly GenericMapper<Model, Entity> _mapper = new GenericMapper<Model, Entity>();

        /// <summary>
        /// Retourne un model
        /// </summary>
        /// <param name="e">Entité à chercher</param>
        /// <returns>Model associé, null si non trouvé</returns>
        public Model? GetModel(Entity e)
        {
            return _mapper.GetT(e);
        }

        /// <summary>
        /// Retourne une entité
        /// </summary>
        /// <param name="e">Model à chercher</param>
        /// <returns>Entité associé, null si non trouvé</returns>
        public Entity? GetEntity(Model m)
        {
            return _mapper.GetU(m);
        }

        /// <summary>
        /// Ajoute un couple Entité/Model
        /// </summary>
        /// <param name="m">Model à ajouter</param>
        /// <param name="e">Entité à ajouter</param>
        /// <returns></returns>
        public bool Add(Model m, Entity e)
        {
            return _mapper.Add(e, m);
        }

        /// <summary>
        /// Reset tout les éléments du mapper
        /// </summary>
        public void Reset()
        {
            _mapper.Reset();
        }
    }
}
